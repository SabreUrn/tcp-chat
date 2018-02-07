using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatClient {
    class Program {
        static void Main(string[] args) {
            bool serverFound = false;
            while (!serverFound) {
                try {
                    TcpClient clientSocket = new TcpClient("localhost", 6789);
                    serverFound = true;
                } catch (SocketException) {
                    Console.WriteLine("Cannot find server. Check if server is running.");
                    Console.WriteLine("Retrying in 5 seconds.");
                    System.Threading.Thread.Sleep(5000);
                }
            }
            Console.WriteLine("Successfully connected to server.");
            Console.ReadLine();
        }
    }
}
