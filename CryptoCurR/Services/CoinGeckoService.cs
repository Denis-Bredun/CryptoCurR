using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Messages;

namespace CryptoCurR.Services
{
    public class CoinGeckoService(
            ICoinGeckoClient client,
            ICoinGeckoParser parser,
            INetworkCheckService networkCheckService,
            IErrorHandler errorHandler) : ICoinGeckoService
    {      
        public Task<List<CoinMarketModel>?> GetTopCoinsAsync(int perPage = DefaultArguments.CoinsMarketsPerPage, int page = DefaultArguments.CoinsMarketsDefaultPage)
        {
            string context = "getting top coins";
            return ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetTopCoinsJsonAsync(perPage, page);
                    return parser.ParseTopCoins(json);
                }, context);
        }

        public Task<CoinDetailModel?> GetCoinDetailsAsync(string id)
        {
            string context = $"getting coin details for '{id}'";
            return ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetCoinDetailsJsonAsync(id);
                    return parser.ParseCoinDetails(json);
                }, context);
        }

        public Task<CoinSearchResult?> SearchCoinsAsync(string query)
        {
            string context = $"searching coins for query '{query}'";
            return ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetSearchJsonAsync(query);
                    return parser.ParseSearchResult(json);
                }, context);
        }

        public Task<MarketChartData?> GetMarketChartAsync(string id, int days = DefaultArguments.DefaultPeriodInDays)
        {
            string context = $"loading market chart for '{id}'";
            return ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetMarketChartJsonAsync(id, days);
                    return parser.ParseMarketChart(json);
                }, context);
        }

        public Task<List<OhlcCandle>?> GetOhlcAsync(string id, int days = DefaultArguments.DefaultPeriodInDays)
        {
            string context = $"loading OHLC data for '{id}'";
            return ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetOhlcJsonAsync(id, days);
                    return parser.ParseOhlc(json);
                }, context);
        }

        public Task<CoinTickersResponse?> GetTickersAsync(string id)
        {
            string context = $"loading tickers for '{id}'";
            return ExecuteWithHandlingAsync(
                async () =>
                {
                    var json = await client.GetTickersJsonAsync(id);
                    return parser.ParseTickers(json);
                }, context);
        }

        private async Task<T?> ExecuteWithHandlingAsync<T>(Func<Task<T?>> action, string context, Func<Exception, string>? getErrorNotification = null)
            where T : class
        {
            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                errorHandler.HandleWarning(LogMessages.NetworkUnavailable, context, Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                return await action();
            }
            catch (HttpRequestException ex)
            {
                errorHandler.HandleError(ex, LogMessages.HttpError, context, string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                errorHandler.HandleError(ex, LogMessages.JsonError, context, string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
            catch (Exception ex) when (typeof(T) == typeof(List<OhlcCandle>) &&
                                       (ex is OverflowException or IndexOutOfRangeException or ArgumentOutOfRangeException))
            {
                errorHandler.HandleError(ex, LogMessages.OhlcParsingError, context, Notifications.OhlcParsingErrorNotification);
                return null;
            }
        }
    }
}
