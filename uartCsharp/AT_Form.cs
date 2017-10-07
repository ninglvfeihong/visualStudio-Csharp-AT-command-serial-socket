using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace uartCsharp
{
    public partial class AT_Form : Form
    {
        private const string str_COM_open = "Open";
        private const string str_COM_close = "Close";
        private Socket socket { set; get; }
        //ATSocketServer atScoketServer;
        private const int bufferLength = 512;
        private int client_counter = 0;
        private Socket latest_client=null;
        public AT_Form()
        {
            InitializeComponent();
            initComponentStatus();
        }

        private void AT_Form_Load(object sender, EventArgs e)
        {
        }

        private void COM_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void serialPortReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //++++++++++++++++++++++++++++++++++++++++++++++
            //CheckForIllegalCrossThreadCalls = false;

            Invoke((MethodInvoker)delegate
            {
                string str = serialPort.ReadExisting();
                try
                {
                    if (str.Length > 0)
                    {
                        if (latest_client != null)
                        {
                            latest_client.Send(Encoding.ASCII.GetBytes(str));
                            displayStatus("Sent Response");
                        }
                        else
                        {
                            displayStatus("Sent Response Error:no client");
                            displayStatus("Msg: " + str);
                        }
                    }
                }
                catch
                {
                    displayStatus("Sent Response Error");
                    latest_client.Close();
                    displayStatus("One client is closed");
                    latest_client = null;
                    increaseClient_n(false);
                }
            });
        }

        private void btn_COM_Open_Click(object sender, EventArgs e)
        {
            if (btn_COM_Open.Text == str_COM_open)
            {
                this.text_COM_Send.Text = "";
                this.btn_COM_Send.Enabled = true;
                if (this.comb_Baud_Rate.Text == "" || this.comb_COM_Ports.Text == "")
                {
                    text_COM_Send.Text = "Lack COM port";
                }
                else
                {
                    try
                    {
                        // make sure port isn't open	
                        if (!this.serialPort.IsOpen)
                        {
                            this.serialPort.PortName = this.comb_COM_Ports.Text;
                            this.serialPort.BaudRate = int.Parse(this.comb_Baud_Rate.Text);
                            this.text_COM_Send.Text = "Enter command here!";
                            this.serialPort.Open();
                            this.btn_COM_Open.Text = str_COM_close;
                            tool_COM_Status.Value += 50;
                        }
                        else
                            this.text_COM_Send.Text = "Port is openned";
                    }
                    catch (UnauthorizedAccessException)
                    {
                        this.text_COM_Send.Text = "UnauthorizedAccess";
                    }
                }
            }
            else
            {
                this.text_COM_Send.Text = "";
                this.serialPort.Close();
                this.btn_COM_Send.Enabled = false;
                this.btn_COM_Open.Text = str_COM_open;
                tool_COM_Status.Value -= 50;
            }

        }

        private void btn_COM_Send_Click(object sender, EventArgs e)
        {
            string name = this.serialPort.PortName;
            // write to serial
            if (this.serialPort.IsOpen)
                //this->_serialPort->WriteLine(String::Format("<{0}>: {1}",name,message));
                this.serialPort.Write(this.text_COM_Send.Text+"\r");
            else
                this.text_COM_Send.Text = "Port Not Opened";

        }

        //private void onSocketRead(Socket socket, string msg){
        //    Invoke((MethodInvoker)delegate
        //    {
        //        this.text_info.Text += msg+"\n";
        //    });
        //    try
        //    {
        //        socket.Send(Encoding.ASCII.GetBytes(msg));
        //    }
        //    catch
        //    {
        //        socket.Close();
        //    }
        //}
        private void initComponentStatus()
        {
            initSerialPorts();
            this.comb_Baud_Rate.SelectedIndex = 0;
            this.btn_COM_Send.Enabled = false;
            this.btn_COM_Open.Text = str_COM_open;
        }

        private void initSerialPorts()
        {
            Object[] ports = System.IO.Ports.SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                Array.Sort(ports);
                comb_COM_Ports.Items.AddRange(ports);
                comb_COM_Ports.SelectedIndex = 0;
            }
            serialPort.DataReceived += serialPortReceivedHandler;
        }

        private void initSocket(int port){
            //atScoketServer = new ATSocketServer();
            //atScoketServer.newDataHandler = onSocketRead;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Any, port));
                socket.Listen(5);
                socket.BeginAccept(bufferLength, new AsyncCallback(acceptedCallBack), null);

                btn_Socket_Open.Enabled = false;
                text_Sock_Addr.Text = GetIP() + ": "+port;
                tool_Sock_Address.Text = text_Sock_Addr.Text;
                tool_COM_Status.Value += 50;
                displayStatus("waiting for client...");
            }
            catch
            {
                displayStatus("Socket initialization Error!");
            }
        }
     

        private void acceptedCallBack(IAsyncResult IA)
        {
            try
            {
                ClientData clientData= new ClientData();
                clientData.buffer = new byte[bufferLength];
                clientData.socket = socket.EndAccept(IA);

                //update client number
                Invoke((MethodInvoker)delegate
                {
                    increaseClient_n(true);
                });
                clientData.socket.BeginReceive(clientData.buffer, 0, bufferLength,
                    SocketFlags.None, receivedCallback, clientData);
                socket.BeginAccept(bufferLength, new AsyncCallback(acceptedCallBack), null);
            }
            catch
            {
                Invoke((MethodInvoker)delegate 
                {
                    displayStatus("accept Error\n");                
                });
            }
        }
        private void receivedCallback(IAsyncResult IA)
        {
            ClientData clientData = (ClientData)IA.AsyncState;
            Socket client = clientData.socket;
            byte[] buf = clientData.buffer;
            try
            {
                int length = client.EndReceive(IA);
                if (length < 1) throw new Exception("no message Error");
                string msg = Encoding.ASCII.GetString(buf, 0, length);
                //do task
                Invoke((MethodInvoker)delegate
                {
                    displayStatus("Received command");
                    dealWithSocketMsg(msg,client);
                    //client.Send(Encoding.ASCII.GetBytes(msg));
                });

                clientData.socket.BeginReceive(clientData.buffer, 0, bufferLength,
                    SocketFlags.None, receivedCallback, clientData);
            }
            catch
            {
                client.Close();
                Invoke((MethodInvoker)delegate
                {
                    displayStatus( "One Client closed");
                    increaseClient_n(false);
                });
            }
        }
        public string GetIP()
        {
            string hostName = System.Net.Dns.GetHostName();
            IPAddress[] addrs = System.Net.Dns.GetHostAddresses(hostName);
            foreach (IPAddress i in addrs)
            {
                if (i.AddressFamily == AddressFamily.InterNetwork)
                {
                    return i.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void btn_Socket_Open_Click(object sender, EventArgs e)
        {
            try
            {
                int port = 0;
                string portStr = text_Socket_port.Text;
                port = int.Parse(portStr);
                if (port <= 1024) throw new Exception("Port out of Range!");
                initSocket(port);

            }
            catch
            {
                text_Sock_Addr.Text = "Port Error";
                displayStatus("Port is number >1024");
            }
        }
        void displayStatus(string str)
        {
            
            if (text_info.Text.Length < 1024)
            {
                text_info.Text += "\r\n"+str;
            }
            else
            {
                text_info.Text = "\r\n"+str;
            }
        }
        private void increaseClient_n(bool isIncrease)
        {
            if (isIncrease)
            {
                client_counter++;
                tool_Sock_Client_n.Text =  "Current Clents: "+ client_counter.ToString()+ "  ";
            }
            else
            {
                client_counter--;
                tool_Sock_Client_n.Text = "Current Clents: " + client_counter.ToString() + "  ";
            }
        }
        void dealWithSocketMsg(string msg,Socket socket){
            try
            {
                if (this.serialPort.IsOpen)
                {
                    this.serialPort.Write(msg.Trim() + "\r");
                    latest_client = socket;
                }
                else
                {
                    this.text_COM_Send.Text = "Port Not Opened";
                    try
                    {
                        if (msg.Length > 0)
                        {
                            socket.Send(Encoding.ASCII.GetBytes("No Uart port\n\r"));
                            displayStatus("No Uart port\n\r");
                           
                        }
                    }
                    catch
                    {
                        displayStatus("Sent Response Error");
                        socket.Close();
                        displayStatus("One client is closed");
                        latest_client = null;
                        increaseClient_n(false);
                    }
                }
            }
            catch
            {
                displayStatus("COM Port Error");
            }
        }

        private void tool_Sock_Client_n_Click(object sender, EventArgs e)
        {

        }

      
    }
    class ClientData
    {
        public Socket socket { get; set; }
        public byte[] buffer { get; set; }
    }
}
