using CryptoCurR.Models;

namespace CryptoCurR.Interfaces
{
    public interface ICurrencyConverterService
    {
        Task<List<CoinMarketModel>> LoadCurrenciesAsync();
        Task<decimal> ConvertCurrencyAsync(string fromId, string toId, string toSymbol, decimal amount);
    }
} 