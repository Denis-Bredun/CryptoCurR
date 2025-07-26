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
        Notifier notifier) : ICoinGeckoService
    {
        public async Task<List<CoinMarketModel>?> GetTopCoinsAsync(
    int perPage = DefaultArguments.CoinsMarketsPerPage,
    int page = DefaultArguments.CoinsMarketsDefaultPage)
        {
            const string context = "getting top coins";

            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                Log.Warning(LogMessages.NetworkUnavailable, context);
                notifier.ShowWarning(Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                var json = await client.GetTopCoinsJsonAsync(perPage, page);
                return parser.ParseTopCoins(json);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, LogMessages.HttpError, context);
                notifier.ShowError(string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                Log.Error(ex, LogMessages.JsonError, context);
                notifier.ShowError(string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
        }

        public async Task<CoinDetailModel?> GetCoinDetailsAsync(string id)
        {
            string context = $"getting coin details for '{id}'";

            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                Log.Warning(LogMessages.NetworkUnavailable, context);
                notifier.ShowWarning(Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                var json = await client.GetCoinDetailsJsonAsync(id);
                return parser.ParseCoinDetails(json);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, LogMessages.HttpError, context);
                notifier.ShowError(string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                Log.Error(ex, LogMessages.JsonError, context);
                notifier.ShowError(string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
        }

        public async Task<CoinSearchResult?> SearchCoinsAsync(string query)
        {
            string context = $"searching coins for query '{query}'";

            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                Log.Warning(LogMessages.NetworkUnavailable, context);
                notifier.ShowWarning(Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                var json = await client.GetSearchJsonAsync(query);
                return parser.ParseSearchResult(json);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, LogMessages.HttpError, context);
                notifier.ShowError(string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                Log.Error(ex, LogMessages.JsonError, context);
                notifier.ShowError(string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
        }


        public async Task<MarketChartData?> GetMarketChartAsync(string id, int days = DefaultArguments.DefaultPeriodInDays)
        {
            string context = $"loading market chart for '{id}'";

            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                Log.Warning(LogMessages.NetworkUnavailable, context);
                notifier.ShowWarning(Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                var json = await client.GetMarketChartJsonAsync(id, days);
                return parser.ParseMarketChart(json);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, LogMessages.HttpError, context);
                notifier.ShowError(string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                Log.Error(ex, LogMessages.JsonError, context);
                notifier.ShowError(string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
        }

        public async Task<List<OhlcCandle>?> GetOhlcAsync(
            string id,
            int days = DefaultArguments.DefaultPeriodInDays)
        {
            string context = $"loading OHLC data for '{id}'";

            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                Log.Warning(LogMessages.NetworkUnavailable, context);
                notifier.ShowWarning(Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                var json = await client.GetOhlcJsonAsync(id, days);
                return parser.ParseOhlc(json);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, LogMessages.HttpError, context);
                notifier.ShowError(string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                Log.Error(ex, LogMessages.JsonError, context);
                notifier.ShowError(string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
            catch (Exception ex) when (
                ex is OverflowException or
                IndexOutOfRangeException or
                ArgumentOutOfRangeException)
            {
                Log.Error(ex, LogMessages.OhlcParsingError, id);
                notifier.ShowError(Notifications.OhlcParsingErrorNotification);
                return null;
            }
        }

        public async Task<CoinTickersResponse?> GetTickersAsync(string id)
        {
            string context = $"loading tickers for '{id}'";

            if (!await networkCheckService.IsInternetAvailableAsync())
            {
                Log.Warning(LogMessages.NetworkUnavailable, context);
                notifier.ShowWarning(Notifications.NetworkErrorNotification);
                return null;
            }

            try
            {
                var json = await client.GetTickersJsonAsync(id);
                return parser.ParseTickers(json);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, LogMessages.HttpError, context);
                notifier.ShowError(string.Format(Notifications.HttpErrorNotification, context));
                return null;
            }
            catch (JsonException ex)
            {
                Log.Error(ex, LogMessages.JsonError, context);
                notifier.ShowError(string.Format(Notifications.JsonErrorNotification, context));
                return null;
            }
        }
    }
}
