using CryptoCurR.DTOs;
using CryptoCurR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Services
{
    public class CoinDetailsLoader(
        ICoinGeckoService service, 
        ICoinDetailsMapper mapper) : ICoinDetailsLoader
    {
        public async Task<CoinDetailsLoadDto> LoadAllAsync(string coinId, int days)
        {
            var detailsTask = service.GetCoinDetailsAsync(coinId);
            var tickersTask = service.GetTickersAsync(coinId);
            var chartTask = service.GetMarketChartAsync(coinId, days);
            var ohlcTask = service.GetOhlcAsync(coinId, days);

            await Task.WhenAll(detailsTask, tickersTask, chartTask, ohlcTask);

            return mapper.MapToDto(
                await detailsTask,
                await tickersTask,
                await chartTask,
                await ohlcTask);
        }

        public async Task<CoinChartDataDto> LoadChartAsync(string coinId, int days)
        {
            var chartTask = service.GetMarketChartAsync(coinId, days);
            var ohlcTask = service.GetOhlcAsync(coinId, days);

            await Task.WhenAll(chartTask, ohlcTask);

            return mapper.MapToDto(
                await chartTask,
                await ohlcTask);
        }
    }
}
