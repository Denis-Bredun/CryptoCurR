using CryptoCurR.Interfaces;
using CryptoCurR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Tests.IntegrationTests
{
    public class CoinGeckoClientTests
    {
        private readonly ICoinGeckoClient _client;

        public CoinGeckoClientTests()
        {
            var httpClient = new HttpClient();
            _client = new CoinGeckoClient(httpClient);
        }

        // If you run all of the tests at the same time, some of them will probably fail because of 429: TooManyRequests.
        // If it happens, just run failed tests in like 2 minutes. It seems like the CoinGenkoAPI just requires some delay in requests

        [Fact]
        public async Task GetTopCoinsJsonAsync_Should_Succeed()
        {
            var result = await _client.GetTopCoinsJsonAsync();
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetCoinDetailsJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetCoinDetailsJsonAsync(TestConstants.ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetSearchJsonAsync_Should_Succeed_For_ValidQuery()
        {
            var result = await _client.GetSearchJsonAsync(TestConstants.ValidSearchQuery);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetMarketChartJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetMarketChartJsonAsync(TestConstants.ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetOhlcJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetOhlcJsonAsync(TestConstants.ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetTickersJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetTickersJsonAsync(TestConstants.ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetSimplePriceJsonAsync_Should_Succeed_For_ValidIds()
        {
            var result = await _client.GetSimplePriceJsonAsync(TestConstants.ValidToId, TestConstants.ValidFromId, TestConstants.ValidToSymbol);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetCoinDetailsJsonAsync_Should_Fail_For_InvalidId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetCoinDetailsJsonAsync(TestConstants.InvalidCoinId);
            });
        }

        [Fact]
        public async Task GetMarketChartJsonAsync_Should_Fail_For_InvalidId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetMarketChartJsonAsync(TestConstants.AnotherInvalidCoinId);
            });
        }

        [Fact]
        public async Task GetOhlcJsonAsync_Should_Fail_For_InvalidId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetOhlcJsonAsync(TestConstants.AnotherInvalidCoinId);
            });
        }

        [Fact]
        public async Task GetTickersJsonAsync_Should_Fail_For_EmptyId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetTickersJsonAsync(TestConstants.EmptyCoinId);
            });
        }

        [Fact]
        public async Task GetSimplePriceJsonAsync_Should_Fail_For_InvalidIds()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetSimplePriceJsonAsync(TestConstants.InvalidToId, TestConstants.InvalidFromId, TestConstants.ValidToSymbol);
            });
        }
    }
}
