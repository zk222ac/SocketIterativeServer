using System;
using System.Net;
using System.Net.Sockets;

namespace SocketIterativeServer
{
    class TcpConnectors
    {
        private readonly IPAddress _ipAddress;
        private readonly int _portNo;
        private TcpListener _serverSocket = null;

        public TcpConnectors(IPAddress ipAddress, int portNo)
        {
            _ipAddress = ipAddress;
            _portNo = portNo;
        }

        public void ConnectServer()
        {
            _serverSocket =  new TcpListener(_ipAddress , _portNo);
            _serverSocket.Start();
            while (true)
            {
                Console.WriteLine("Server is ready for handshake");
                TcpClient connectionSocket = _serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated now");
                EchoService service = new EchoService(connectionSocket);
                service.DoIt();
            }
            _serverSocket.Stop();
        }
    }
}
