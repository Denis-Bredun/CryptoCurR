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
    public class CoinGeckoClient(HttpClient httpClient) : ICoinGeckoClient
    {
        public async Task<string> GetTopCoinsJsonAsync(
            int perPage = DefaultArguments.CoinsMarketsPerPage,
            int page = DefaultArguments.CoinsMarketsDefaultPage)
        {
            var url = CoinGeckoApi.GetMarketsUrl(perPage: perPage, page: page);
            return await SendAndCheckGetRequestAsync(url);
        }

        public async Task<string> GetCoinDetailsJsonAsync(string id)
        {
            var url = CoinGeckoApi.GetCoinUrl(id);
            return await SendAndCheckGetRequestAsync(url);
        }

        public async Task<string> GetSearchJsonAsync(string query)
        {
            var url = CoinGeckoApi.GetSearchUrl(query);
            return await SendAndCheckGetRequestAsync(url);
        }

        public async Task<string> GetMarketChartJsonAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            var url = CoinGeckoApi.GetMarketChartUrl(id, days);
            return await SendAndCheckGetRequestAsync(url);
        }

        public async Task<string> GetOhlcJsonAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            var url = CoinGeckoApi.GetOhlcUrl(id, days);
            return await SendAndCheckGetRequestAsync(url);
        }

        public async Task<string> GetTickersJsonAsync(string id)
        {
            var url = CoinGeckoApi.GetTickersUrl(id);
            return await SendAndCheckGetRequestAsync(url);
        }

        private async Task<string> SendAndCheckGetRequestAsync(string url)
        {
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var message = string.Format(
                    ExceptionMessages.HttpRequestFailedTemplate,
                    response.StatusCode,
                    content);

                throw new HttpRequestException(message);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
