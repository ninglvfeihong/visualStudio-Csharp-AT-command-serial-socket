using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace socketServer
{
    class Program
    {
        static byte[] buf { get; set; }
        static Socket socket;
        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any,4444));
            socket.Listen(10);
            Socket accepted = socket.Accept();
            buf = new byte[512];
            int byteRead = accepted.Receive(buf,buf.Length,0);
            string str = Encoding.ASCII.GetString(buf, 0, byteRead);
            Console.WriteLine(str);
            Console.Read();
            socket.Close();
        }
    }
}
