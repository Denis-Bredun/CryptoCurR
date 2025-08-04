using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;

namespace CryptoCurR.Services
{
    public class CurrencyConverterService(ICoinGeckoService coinGeckoService) : ICurrencyConverterService
    {
        public async Task<List<CoinMarketModel>> LoadCurrenciesAsync()
        {
            var coins = await coinGeckoService.GetTopCoinsAsync(perPage: 250);
            return coins ?? new List<CoinMarketModel>();
        }

        public async Task<decimal> ConvertCurrencyAsync(string fromId, string toId, string toSymbol, decimal amount)
        {
            var simplePrice = await coinGeckoService.GetSimplePriceAsync(fromId, toId, toSymbol);
            var rate = simplePrice.Prices[fromId][toSymbol];
            return amount * rate;
        }
    }
} 