using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Tests
{
    public class CoinGeckoServiceMock(
        ICoinGeckoClient client, 
        ICoinGeckoParser parser,
        INetworkCheckService networkCheckService) : ICoinGeckoService
    {
        public async Task<List<CoinMarketModel>?> GetTopCoinsAsync(
            int perPage = DefaultArguments.CoinsMarketsPerPage,
            int page = DefaultArguments.CoinsMarketsDefaultPage)
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                var json = await client.GetTopCoinsJsonAsync(perPage, page);
                return parser.ParseTopCoins(json);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
        }

        public async Task<CoinDetailModel?> GetCoinDetailsAsync(string id)
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                var json = await client.GetCoinDetailsJsonAsync(id);
                return parser.ParseCoinDetails(json);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
        }

        public async Task<CoinSearchResult?> SearchCoinsAsync(string query)
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                var json = await client.GetSearchJsonAsync(query);
                return parser.ParseSearchResult(json);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
        }

        public async Task<MarketChartData?> GetMarketChartAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                var json = await client.GetMarketChartJsonAsync(id, days);
                return parser.ParseMarketChart(json);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
        }

        public async Task<List<OhlcCandle>?> GetOhlcAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                var json = await client.GetOhlcJsonAsync(id, days);
                return parser.ParseOhlc(json);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
            catch (Exception ex) when (
                ex is OverflowException ||
                ex is IndexOutOfRangeException ||
                ex is ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        public async Task<CoinTickersResponse?> GetTickersAsync(string id)
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                var json = await client.GetTickersJsonAsync(id);
                return parser.ParseTickers(json);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
        }
    }
}
