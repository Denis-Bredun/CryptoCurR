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
        private readonly CoinGeckoClient _client;

        private const string ValidCoinId = "bitcoin";
        private const string ValidSearchQuery = "eth";
        private const string InvalidCoinId = "invalid_coin_id";
        private const string AnotherInvalidCoinId = "some_invalid_id";
        private const string EmptyCoinId = "";

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
            var result = await _client.GetCoinDetailsJsonAsync(ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetSearchJsonAsync_Should_Succeed_For_ValidQuery()
        {
            var result = await _client.GetSearchJsonAsync(ValidSearchQuery);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetMarketChartJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetMarketChartJsonAsync(ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetOhlcJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetOhlcJsonAsync(ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetTickersJsonAsync_Should_Succeed_For_ValidId()
        {
            var result = await _client.GetTickersJsonAsync(ValidCoinId);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task GetCoinDetailsJsonAsync_Should_Fail_For_InvalidId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetCoinDetailsJsonAsync(InvalidCoinId);
            });
        }

        [Fact]
        public async Task GetMarketChartJsonAsync_Should_Fail_For_InvalidId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetMarketChartJsonAsync(AnotherInvalidCoinId);
            });
        }

        [Fact]
        public async Task GetOhlcJsonAsync_Should_Fail_For_InvalidId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetOhlcJsonAsync(AnotherInvalidCoinId);
            });
        }

        [Fact]
        public async Task GetTickersJsonAsync_Should_Fail_For_EmptyId()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _client.GetTickersJsonAsync(EmptyCoinId);
            });
        }
    }
}
