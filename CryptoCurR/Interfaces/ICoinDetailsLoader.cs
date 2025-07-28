using CryptoCurR.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface ICoinDetailsLoader
    {
        Task<CoinDetailsLoadDto> LoadAllAsync(string coinId, int days);
        Task<CoinChartDataDto> LoadChartAsync(string coinId, int days);
    }
}
