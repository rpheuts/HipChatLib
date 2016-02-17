using HipChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HipChat.API
{
    public class RoomsApi
    {
        private HipChatConnection _connection;

        public RoomsApi(HipChatConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<RoomReference>> GetRoomReferencesAsync()
        {
            return await _connection.GetListRequest<List<RoomReference>>("room");
        }

        public async Task<Room> GetRoom(string roomName)
        {
            return await _connection.GetRequest<Room>("room/" + roomName);
        }

        public async Task<bool> SendMessage(string roomName, string message)
        {
            return await _connection.PostRequest("room/" + roomName + "/message", new { message = message });
        }

        public async Task<bool> SendNotification(string roomName, string message, bool html = false)
        {
            return await _connection.PostRequest("room/" + roomName + "/notification", 
                new { message = message,
                    color = "yellow",
                    from = "Poky",
                    message_format = html ? "html" : "text"
                });
        }
    }
}
