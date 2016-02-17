using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HipChat.Models
{
    public class Room : Entity
    {
        [JsonProperty("xmpp_jid")]
        public string JabberId { get; set; }

        [JsonProperty("last_active")]
        public Nullable<DateTime> LastActive { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("guest_access")]
        public string GuessAccess { get; set; }

        [JsonProperty("owner_user_id")]
        public string OwnerUserId { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("is_guest_accessible")]
        public bool IsGuestAccessible { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("owner")]
        public Mention Owner { get; set; }

        [JsonProperty("guest_access_url")]
        public string GuestAccessUrl { get; set; }
    }
}
