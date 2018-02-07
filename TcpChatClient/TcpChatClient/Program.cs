using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatClient {
    class Program {
        static void Main(string[] args) {
            TcpClient clientSocket;
            bool serverFound = false;
            /*
            while (!serverFound) {
                try {
                    clientSocket = new TcpClient("localhost", 6789);
                    serverFound = true;
                } catch (SocketException) {
                    Console.WriteLine("Cannot find server. Check if server is running.");
                    Console.WriteLine("Retrying in 5 seconds.");
                    System.Threading.Thread.Sleep(5000);
                }
            }
            */
            clientSocket = new TcpClient("localhost", 6789);
            Console.WriteLine("Successfully connected to server.");

            NetworkStream ns = clientSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);

            string readMessage = null;
            string writeMessage = null;
            while (true) {
                readMessage = sr.ReadLine();
                Console.WriteLine("Server: " + readMessage);
                writeMessage = Console.ReadLine();
                sw.WriteLine(writeMessage);
            }
        }
    }
}
