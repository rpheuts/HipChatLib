using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HipChat.Models
{
    public class RoomReference : Entity
    {
        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }
    }
}
