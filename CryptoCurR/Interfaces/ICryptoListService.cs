using CryptoCurR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface ICryptoListService
    {
        Task<List<CoinMarketModel>> LoadTopCoinsAsync(int page, int coinsPerPage);
        Task<List<CoinMarketModel>> SearchCoinsAsync(string query);
    }
}
