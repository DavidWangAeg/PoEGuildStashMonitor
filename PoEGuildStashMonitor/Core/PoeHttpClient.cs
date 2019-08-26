using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoEGuildStashMonitor.Core
{
    public class PoeHttpClient : Singleton<PoeHttpClient>
    {
        private const string BaseAddress = "https://www.pathofexile.com";
        private const string AddressFormat = "/api/guild/{0}/stash/history?from={1}&fromid={2}";

        private HttpClient client;

        public async Task<string> GetHistoryAsync(string guildId, string fromEpochTime, string fromId = "")
        {
            EnsureInitialized();

            string request = string.Format(AddressFormat, guildId, fromEpochTime, fromId);
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, request);
            Authentication.Instance.AddAuthHeader(msg);

            try
            {
                HttpResponseMessage response = await client.SendAsync(msg);
                return await response.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException)
            {
                // Request timed out
                return string.Empty;
            }
            catch (HttpRequestException e)
            {
                // TODO: Handle exceptions
            }

            return string.Empty;
        }

        private void EnsureInitialized()
        {
            if (client == null)
            {
                var handler = new HttpClientHandler() { UseCookies = false };
                client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) };
            }
        }
    }
}