using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Services
{
    public class CryptoListService(ICoinGeckoService coinGeckoService) : ICryptoListService
    {
        public async Task<List<CoinMarketModel>> LoadTopCoinsAsync(int page, int coinsPerPage)
        {
            var result = await coinGeckoService.GetTopCoinsAsync(coinsPerPage, page);
            return result ?? new List<CoinMarketModel>();
        }

        public async Task<List<CoinMarketModel>> SearchCoinsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await LoadTopCoinsAsync(1, 10);

            var result = await coinGeckoService.SearchCoinsAsync(query);
            var list = new List<CoinMarketModel>();

            if (result?.Coins != null)
            {
                foreach (var item in result.Coins)
                {
                    list.Add(new CoinMarketModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Symbol = item.Symbol,
                        Image = item.Large,
                        MarketCapRank = item.MarketCapRank
                    });
                }
            }

            return list;
        }
    }
}
