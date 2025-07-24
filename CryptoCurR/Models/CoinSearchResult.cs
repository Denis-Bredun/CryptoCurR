using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Models
{
    public class CoinSearchResult
    {
        public List<CoinSearchItem>? Coins { get; set; }
    }

    public class CoinSearchItem
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ApiSymbol { get; set; }
        public string? Symbol { get; set; }
        public int? MarketCapRank { get; set; }
        public string? Thumb { get; set; }
        public string? Large { get; set; }
    }
}
