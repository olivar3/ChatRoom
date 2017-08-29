using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {       
        Client client;
        TcpListener server;
        public Server()
        {
               
                TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
                TcpClient client = default(TcpClient);
                server.Start();
                Console.WriteLine("Please wait for connection...");
                

            while (true)
            {
                Dictionary<string, Client> users = new Dictionary<string, Client>();
                client = server.AcceptTcpClient();
                Console.WriteLine("You are now connected!");
                Console.WriteLine("Please enter a Username");
                Console.ReadKey();


             
            }

        }
        public void Run()
        {
            AcceptClient();
            string message = client.Receive();
            Respond(message);
        }
        private void AcceptClient()
        {
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
            }

        }
        public void AddNewClient(Client client)
        {
            Thread addClient = new Thread(() => AddNewClient(client));

        }
        private void Respond(string body)
        {
             client.Send(body);
        }
    }
}
