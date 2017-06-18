using System;
using Newtonsoft.Json;

namespace ControleViagem.Models
{
    public class FacebookUser
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }
    }
}
