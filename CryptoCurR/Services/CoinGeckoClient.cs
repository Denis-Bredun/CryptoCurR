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
    public class CoinGeckoClient : ICoinGeckoClient
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; CoinApp/1.0)");
        }

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

        public async Task<string> GetSimplePriceJsonAsync(
            string toId, 
            string fromId, 
            string toSymbol, 
            int precision = DefaultArguments.DefaultPricePrecision)
        {
            var url = CoinGeckoApi.GetSimplePriceUrl(toId, fromId, toSymbol, precision);
            return await SendAndCheckGetRequestAsync(url);
        }

        private async Task<string> SendAndCheckGetRequestAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var message = string.Format(
                    ExceptionMessages.HttpRequestFailedTemplate,
                    (int)response.StatusCode,
                    response.StatusCode,
                    content);

                throw new HttpRequestException(message);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
