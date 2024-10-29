using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Luval.DynamicDNS
{
    public class IPInformation
    {
        public string? PublicIP { get; set; } = default;

        public DateTime UtcUpdatedOn { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static IPInformation Create(string json) => JsonConvert.DeserializeObject<IPInformation>(json);
    }
}
