using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoCurR.Services
{
    public class CoinGeckoService(ICoinGeckoClient client, ICoinGeckoParser parser) : ICoinGeckoService
    {
        public async Task<List<CoinMarketModel>?> GetTopCoinsAsync(
            int perPage = DefaultArguments.CoinsMarketsPerPage,
            int page = DefaultArguments.CoinsMarketsDefaultPage)
        {
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
