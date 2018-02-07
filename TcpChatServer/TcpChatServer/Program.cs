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
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);

            string readMessage = null;
            string writeMessage = null;
            while (true) {
                writeMessage = Console.ReadLine();
                sw.WriteLine(writeMessage);
                readMessage = sr.ReadLine();
                Console.WriteLine("Client: " + readMessage);
            }
        }
    }
}
