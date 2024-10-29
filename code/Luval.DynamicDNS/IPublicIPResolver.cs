
namespace Luval.DynamicDNS
{
    public interface IPublicIPResolver
    {
        Task<string> GetPublicIpAsync();
    }
}