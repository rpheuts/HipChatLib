using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HipChat.Models
{
    public class Mention
    {
        [JsonProperty("mention_name")]
        public string MentionName { get; set; }
    }
}
