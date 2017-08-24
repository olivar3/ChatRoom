using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Dictionary
    {
        public static void UserList(Client client)
        {
            Dictionary <string IP, int port> Dictionary =
                  new Dictionary<string IP, int port>();

            Dictionary.AddToChat("User1", 1);
            Dictionary.AddToChat("User2", 2);
            Dictionary.AddToChat("User3", 3);
        }
      
    }
}
    

