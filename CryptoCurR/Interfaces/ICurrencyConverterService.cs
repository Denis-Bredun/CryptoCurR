using CryptoCurR.Models;

namespace CryptoCurR.Interfaces
{
    public interface ICurrencyConverterService
    {
        Task<List<CurrencyConverterModel>> LoadCurrenciesAsync();
        Task<decimal> ConvertCurrencyAsync(string fromId, string toId, string toSymbol, decimal amount);
    }
} 