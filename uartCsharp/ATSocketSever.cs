using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace uartCsharp
{
    delegate void NewDataReceivedSocketHandler (Socket socket, string msg);
    class ATSocketServer
    {
        private Socket socket { set; get; }
        private byte[] buf { set; get; }
        private const int bufferLength = 512;
        public NewDataReceivedSocketHandler newDataHandler { set; get; }

        public ATSocketServer ()
        {
            
            buf = new byte[512];
            newDataHandler = null;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 1717));
            socket.Listen(5);
            Thread th = new Thread(listenSocketThread);
            th.Start();            
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
        private void newMsgReceived(Object socket){
            Socket sck = (Socket)socket;
            byte[] buffer = new byte[bufferLength];
            try
            {
                while (true)
                {
                    int length = sck.Receive(buffer, bufferLength, SocketFlags.None);
                    if (length < 1) throw new Exception("no Data Error");//it is very import to check the length. or when the socket is closed, the server will polling all the time, which eats off alomost all the CPU time
                    if (length > 0)
                    {
                        string str = Encoding.ASCII.GetString(buffer, 0, length);
                        if (newDataHandler != null) newDataHandler(sck,str);
                    }
                }
            }
            catch(Exception)
            {
            }
            finally
            {
                sck.Close();
                sck = null;
            }

        }
        private void listenSocketThread()
        {
            while (true)
            {
                Thread th = new Thread(newMsgReceived);
                th.Start(socket.Accept());
            }
        }

    }
}
