using System;
using System.IO;
using System.Net.Sockets;

namespace SocketIterativeServer
{
    // Coupling and Coherence
    class EchoService
    {
        private readonly TcpClient _connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this._connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Stream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns) {AutoFlush = true};// enable automatic flushing
            string message = sr.ReadLine();
            while (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Client: " + message);
                var answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }
            ns.Close();
            _connectionSocket.Close();
        }
    }
}
