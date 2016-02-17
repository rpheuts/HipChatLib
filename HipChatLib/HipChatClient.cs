using HipChat.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HipChat
{
    public class HipChatClient
    { 
        public RoomsApi Rooms { get; set; }

        private HipChatConnection _connection;

        public HipChatClient(HipChatCredentials credentials)
        {
            _connection = new HipChatConnection(credentials);

            Rooms = new RoomsApi(_connection);
        }
    }
}
