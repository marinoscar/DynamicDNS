using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.DynamicDNS
{
    public class PublicIPChangedEventArgs : EventArgs
    {
        public required IPInformation NewPublicIpAddress { get; set; }
        public required IPInformation ExistingPublicIpAddress { get; set;}
    }
}
