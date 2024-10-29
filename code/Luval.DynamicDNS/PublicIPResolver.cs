namespace Luval.DynamicDNS
{
    public class PublicIPResolver : IPublicIPResolver
    {
        public async Task<string> GetPublicIpAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Using an external service to get the public IP
                    HttpResponseMessage response = await client.GetAsync("https://api.ipify.org");
                    response.EnsureSuccessStatusCode();

                    // Read the IP address as a string
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving public IP: " + ex.Message);
                return "Unavailable";
            }
        }

    }
}
