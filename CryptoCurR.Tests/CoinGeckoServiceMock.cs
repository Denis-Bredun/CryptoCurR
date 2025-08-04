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
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetTopCoinsJsonAsync(perPage, page);
                    return parser.ParseTopCoins(json);
                });
        }

        public async Task<CoinDetailModel?> GetCoinDetailsAsync(string id)
        {
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetCoinDetailsJsonAsync(id);
                    return parser.ParseCoinDetails(json);
                });
        }

        public async Task<CoinSearchResult?> SearchCoinsAsync(string query)
        {
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetSearchJsonAsync(query);
                    return parser.ParseSearchResult(json);
                });
        }

        public async Task<MarketChartData?> GetMarketChartAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetMarketChartJsonAsync(id, days);
                    return parser.ParseMarketChart(json);
                });
        }

        public async Task<List<OhlcCandle>?> GetOhlcAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetOhlcJsonAsync(id, days);
                    return parser.ParseOhlc(json);
                });
        }

        public async Task<CoinTickersResponse?> GetTickersAsync(string id)
        {
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetTickersJsonAsync(id);
                    return parser.ParseTickers(json);
                });
        }

        public async Task<SimplePriceModel?> GetSimplePriceAsync(
            string toId, 
            string fromId, 
            string toSymbol, 
            int precision = DefaultArguments.DefaultPricePrecision)
        {
            return await ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetSimplePriceJsonAsync(toId, fromId, toSymbol, precision);
                    return parser.ParseSimplePrice(json);
                });
        }

        private async Task<T?> ExecuteWithHandlingAsync<T>(Func<Task<T?>> action)
            where T : class
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
                return null;

            try
            {
                return await action();
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
    }
}
