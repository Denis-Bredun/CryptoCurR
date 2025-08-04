using CryptoCurR.Constants;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface ICoinGeckoService
    {
        Task<List<CoinMarketModel>?> GetTopCoinsAsync(
            int perPage = DefaultArguments.CoinsMarketsPerPage,
            int page = DefaultArguments.CoinsMarketsDefaultPage);
        Task<CoinDetailModel?> GetCoinDetailsAsync(string id);
        Task<CoinSearchResult?> SearchCoinsAsync(string query);
        Task<MarketChartData?> GetMarketChartAsync(
            string id, 
            int days = DefaultArguments.DefaultPeriodInDays);
        Task<List<OhlcCandle>?> GetOhlcAsync(
            string id, 
            int days = DefaultArguments.DefaultPeriodInDays);
        Task<CoinTickersResponse?> GetTickersAsync(string id);
        Task<SimplePriceModel?> GetSimplePriceAsync(
            string toId, 
            string fromId, 
            string toSymbol, 
            int precision = DefaultArguments.DefaultPricePrecision);
    }
}
