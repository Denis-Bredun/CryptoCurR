using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Services
{
    public class NetworkCheckService(HttpClient httpClient) : INetworkCheckService
    {
        public async Task<bool> IsInternetAvailableAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Head, CoinGeckoApi.BaseSiteUrl);
                var response = await httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }

}
