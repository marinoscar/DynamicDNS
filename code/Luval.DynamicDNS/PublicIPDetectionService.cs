using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.DynamicDNS
{
    public class PublicIPDetectionService
    {

        private IPublicIPResolver _resolver;

        public void Check()
        {
            var current = LocalStorage.GetValue();
            var actual = _resolver.GetPublicIpAsync().Result;

            if(actual != null && actual != current.PublicIP)
            {
                var eventArgs = new PublicIPChangedEventArgs() { ExistingPublicIpAddress = current, NewPublicIpAddress = new IPInformation() { PublicIP = actual } };
                LocalStorage.Persist(eventArgs.NewPublicIpAddress);
                PublicIPChanged?.Invoke(this, eventArgs);
            }
        }

        public EventHandler<PublicIPChangedEventArgs> PublicIPChanged;

        public PublicIPDetectionService( IPublicIPResolver publicIPResolver)
        {
            _resolver = publicIPResolver;
        }
    }
}
