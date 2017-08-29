using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   public class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        Queue<String> queue = new Queue<string>();
        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }
        public void Send(string Message, Queue queue)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);
            stream.Write(message, 0, message.Count());
            queue.Enqueue(message);
        }
        public string Recieve()
        {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
            queue.Dequeue();
            Console.WriteLine(recievedMessageString);
            return recievedMessageString;
        }
        public void newQueue()
        {
    
        }

    }
}
