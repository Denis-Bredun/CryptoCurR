using CryptoCurR.Interfaces;
using CryptoCurR.Models;
using CryptoCurR.Services;
using Moq;
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
        private readonly INetworkCheckService _networkCheckService;
        private readonly Mock<ICoinGeckoClient> _clientMock;
        private readonly Mock<ICoinGeckoParser> _parserMock;
        private readonly Mock<INetworkCheckService> _networkCheckMock;
        private readonly CoinGeckoServiceMock _mockService;

        public CoinGeckoServiceTests()
        {
            var httpClient = new HttpClient();
            _client = new CoinGeckoClient(httpClient);
            _parser = new CoinGeckoParser();
            _networkCheckService = new NetworkCheckService(httpClient);

            _service = new CoinGeckoServiceMock(_client, _parser, _networkCheckService);

            _clientMock = new Mock<ICoinGeckoClient>();
            _parserMock = new Mock<ICoinGeckoParser>();
            _networkCheckMock = new Mock<INetworkCheckService>();

            _mockService = new CoinGeckoServiceMock(
                _clientMock.Object,
                _parserMock.Object,
                _networkCheckMock.Object);
        }

        [Fact]
        public async Task GetTopCoinsAsync_Should_ReturnNull_When_NoInternet()
        {
            _networkCheckMock.Setup(n => n.IsInternetAvailableAsync()).ReturnsAsync(false);

            var result = await _mockService.GetTopCoinsAsync();

            Assert.Null(result);

            _clientMock.Verify(c => c.GetTopCoinsJsonAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetTopCoinsAsync_Should_CallClient_When_InternetAvailable()
        {
            _networkCheckMock.Setup(n => n.IsInternetAvailableAsync()).ReturnsAsync(true);
            _clientMock.Setup(c => c.GetTopCoinsJsonAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync("[]");
            _parserMock.Setup(p => p.ParseTopCoins(It.IsAny<string>())).Returns(new List<CoinMarketModel>());

            var result = await _mockService.GetTopCoinsAsync();

            Assert.NotNull(result);

            _clientMock.Verify(c => c.GetTopCoinsJsonAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _parserMock.Verify(p => p.ParseTopCoins(It.IsAny<string>()), Times.Once);
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

        [Fact]
        public async Task GetSimplePriceAsync_Should_Succeed_For_ValidIds()
        {
            var ex = await Record.ExceptionAsync(() => _service.GetSimplePriceAsync(TestConstants.ValidToId, TestConstants.ValidFromId, TestConstants.ValidToSymbol));
            Assert.Null(ex);
        }
    }

}
