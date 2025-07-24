using CryptoCurR.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface ICoinGeckoClient
    {
        Task<string> GetTopCoinsJsonAsync(
            int perPage = DefaultArguments.CoinsMarketsPerPage,
            int page = DefaultArguments.CoinsMarketsDefaultPage);
        Task<string> GetCoinDetailsJsonAsync(string id);
        Task<string> GetSearchJsonAsync(string query);
        Task<string> GetMarketChartJsonAsync(
            string id, 
            int days = DefaultArguments.DefaultPeriodInDays);
        Task<string> GetOhlcJsonAsync(
            string id, 
            int days = DefaultArguments.DefaultPeriodInDays);        
        Task<string> GetTickersJsonAsync(string id);        
    }
}
