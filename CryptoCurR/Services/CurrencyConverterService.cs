using CryptoCurR.Constants;
using CryptoCurR.Interfaces;
using CryptoCurR.Models;

namespace CryptoCurR.Services
{
    public class CurrencyConverterService(
        ICoinGeckoService coinGeckoService,
        ICoinDetailsMapper coinDetailsMapper) : ICurrencyConverterService
    {
        public async Task<List<CurrencyConverterModel>> LoadCurrenciesAsync()
        {
            var coins = await coinGeckoService.GetTopCoinsAsync(perPage: 250);
            return coinDetailsMapper.MapToCurrencyConverterModels(coins);
        }

        public async Task<decimal> ConvertCurrencyAsync(string fromId, string toId, string toSymbol, decimal amount)
        {
            var simplePrice = await coinGeckoService.GetSimplePriceAsync(fromId, toId, toSymbol);

            if (simplePrice == null || simplePrice[fromId].Count == 0)
                return 0.0m;

            var rate = simplePrice[fromId][toSymbol];
            return Math.Round(amount * rate, 6);
        }
    }
} 