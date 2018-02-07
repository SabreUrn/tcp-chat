using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatClient {
    class Program {
        static void Main(string[] args) {
            TcpClient clientSocket = new TcpClient("localhost", 6789);

            Console.ReadLine();
        }
    }
}
