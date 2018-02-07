using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatServer {
    class Program {
        static void Main(string[] args) {
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine("Server started.");

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Connection accepted, server activated.");

            Console.ReadLine();
        }
    }
}
