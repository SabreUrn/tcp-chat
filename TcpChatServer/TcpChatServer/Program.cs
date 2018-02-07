using System;
using System.Collections.Generic;
using System.IO;
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

            NetworkStream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            string message = null;
            while (message == null) {
                message = sr.ReadLine();
                Console.WriteLine("Client: " + message);
                message = null;
            }

            Console.ReadLine();
        }
    }
}
