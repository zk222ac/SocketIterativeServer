using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketIterativeServer
{
    class Program
    {
       
        //private static IPAddress _ip = IPAddress.Any;
         private static readonly IPAddress Ip = IPAddress.Parse("127.0.0.1");
         private static int _portNo = 6789;

        static void Main(string[] args)
        {
            try
            {
                TcpConnectors tcp = new TcpConnectors(Ip , _portNo);
                tcp.ConnectServer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

        }
    }
}
