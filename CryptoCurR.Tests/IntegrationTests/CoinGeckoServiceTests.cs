using CryptoCurR.Interfaces;
using CryptoCurR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Tests.IntegrationTests
{
    public class CoinGeckoServiceTests
    {
        private readonly ICoinGeckoClient _client;
        private readonly ICoinGeckoParser _parser;
        private readonly ICoinGeckoService _service;

        public CoinGeckoServiceTests()
        {
            var httpClient = new HttpClient();
            _client = new CoinGeckoClient(httpClient);
            _parser = new CoinGeckoParser();

            _service = new CoinGeckoServiceMock(_client, _parser);
        }

        [Fact]
        public async Task GetTopCoinsAsync_Should_Succeed()
        {
            var ex = await Record.ExceptionAsync(() => _service.GetTopCoinsAsync());
            Assert.Null(ex);
        }

        [Fact]
        public async Task GetCoinDetailsAsync_Should_Succeed_For_ValidId()
        {
            var ex = await Record.ExceptionAsync(() => _service.GetCoinDetailsAsync(TestConstants.ValidCoinId));
            Assert.Null(ex);
        }

        [Fact]
        public async Task SearchCoinsAsync_Should_Succeed_For_ValidQuery()
        {
            var ex = await Record.ExceptionAsync(() => _service.SearchCoinsAsync(TestConstants.ValidSearchQuery));
            Assert.Null(ex);
        }

        [Fact]
        public async Task GetMarketChartAsync_Should_Succeed_For_ValidId()
        {
            var ex = await Record.ExceptionAsync(() => _service.GetMarketChartAsync(TestConstants.ValidCoinId));
            Assert.Null(ex);
        }

        [Fact]
        public async Task GetOhlcAsync_Should_Succeed_For_ValidId()
        {
            var ex = await Record.ExceptionAsync(() => _service.GetOhlcAsync(TestConstants.ValidCoinId));
            Assert.Null(ex);
        }

        [Fact]
        public async Task GetTickersAsync_Should_Succeed()
        {
            var ex = await Record.ExceptionAsync(() => _service.GetTickersAsync(TestConstants.ValidCoinId));
            Assert.Null(ex);
        }
    }

}
