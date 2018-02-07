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

            Task<string> readMessage = null;
            Task<string> writeMessage = null;
            while (true) {
                //writeMessage = Console.In.ReadLineAsync();
                //sw.WriteLineAsync(Console.ReadLine());
                WriteMessage(sw);
                readMessage = ReadMessage(sr);
                Console.WriteLine("Client: " + readMessage.Result);
            }
        }

        public static async Task<string> ReadMessage(StreamReader sr) {
            string readMessage = await sr.ReadLineAsync();
            //readMessage = sr.ReadLineAsync();
            return readMessage;
        }

        public static async Task WriteMessage(StreamWriter sw) {
            await sw.WriteLineAsync(Console.ReadLine());
        }
    }
}
