using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Tests
{
    public static class TestConstants
    {
        public const string ValidCoinId = "bitcoin";
        public const string ValidSearchQuery = "eth";

        public const string InvalidCoinId = "invalid_coin_id";
        public const string AnotherInvalidCoinId = "some_invalid_id";
        public const string EmptyCoinId = "";

        public const string ValidToId = "bitcoin";
        public const string ValidFromId = "ethereum";
        public const string ValidToSymbol = "btc";
        public const string InvalidToId = "invalid_id";
        public const string InvalidFromId = "another_invalid_id";
    }
}
