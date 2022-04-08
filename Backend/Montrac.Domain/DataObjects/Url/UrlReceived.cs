using Montrac.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.DataObjects.Url
{
    public class UrlReceived : AuditModel
    {
        //JsonProperty is a helper if the fields are sent with another name
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Uri { get; set; }

        [JsonProperty("browser")]
        public string Browser { get; set; }
        public int UserId { get; set; }
    }

    public class NewUrlReceived
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Uri { get; set; }

        [JsonProperty("browser")]
        public string Browser { get; set; }
        public int UserId { get; set; }
    }
}
