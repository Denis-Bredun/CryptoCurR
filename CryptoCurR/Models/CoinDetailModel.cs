using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Models
{
    public class CoinDetailModel
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public decimal? BlockTimeInMinutes { get; set; }
        public string? HashingAlgorithm { get; set; }
        public string[]? Categories { get; set; }
        public Description? Description { get; set; }
        public Links? Links { get; set; }
        public Image? Image { get; set; }
        public string? GenesisDate { get; set; }
        public decimal? SentimentVotesUpPercentage { get; set; }
        public decimal? SentimentVotesDownPercentage { get; set; }
        public decimal? MarketCapRank { get; set; }
        public MarketData? MarketData { get; set; }
        public DateTime? LastUpdated { get; set; }
        public Ticker[]? Tickers { get; set; }
    }

    public class Description
    {
        public string? En { get; set; }
    }

    public class Links
    {
        public string[]? Homepage { get; set; }
        public string? Whitepaper { get; set; }
        public string[]? BlockchainSite { get; set; }
        public string[]? OfficialForumUrl { get; set; }
        public string[]? ChatUrl { get; set; }
        public string[]? AnnouncementUrl { get; set; }
        public string? SnapshotUrl { get; set; }
        public string? TwitterScreenName { get; set; }
        public string? FacebookUsername { get; set; }
        public decimal? BitcointalkThreadIdentifier { get; set; }
        public string? TelegramChannelIdentifier { get; set; }
        public string? SubredditUrl { get; set; }
        public ReposUrl? ReposUrl { get; set; }
    }

    public class ReposUrl
    {
        public string[]? Github { get; set; }
    }

    public class Image
    {
        public string? Thumb { get; set; }
        public string? Small { get; set; }
        public string? Large { get; set; }
    }

    public class RoiModel
    {
        public decimal? Times { get; set; }
        public string? Currency { get; set; }
        public decimal? Percentage { get; set; }
    }

    public class MarketData
    {
        public Current_Price? CurrentPrice { get; set; }
        public RoiModel? Roi { get; set; }
        public Ath? Ath { get; set; }
        public Ath_Change_Percentage? AthChangePercentage { get; set; }
        public Ath_Date? AthDate { get; set; }
        public Atl? Atl { get; set; }
        public Atl_Change_Percentage? AtlChangePercentage { get; set; }
        public Atl_Date? AtlDate { get; set; }
        public Market_Cap? MarketCap { get; set; }
        public decimal? MarketCapRank { get; set; }
        public Fully_Diluted_Valuation? FullyDilutedValuation { get; set; }
        public decimal? MarketCapFdvRatio { get; set; }
        public Total_Volume? TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public High_24H? High24h { get; set; }

        [JsonProperty("low_24h")]
        public Low_24H? Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        [JsonProperty("price_change_percentage_7d")]
        public decimal? PriceChangePercentage7d { get; set; }

        [JsonProperty("price_change_percentage_14d")]
        public decimal? PriceChangePercentage14d { get; set; }

        [JsonProperty("price_change_percentage_30d")]
        public decimal? PriceChangePercentage30d { get; set; }

        [JsonProperty("price_change_percentage_60d")]
        public decimal? PriceChangePercentage60d { get; set; }

        [JsonProperty("price_change_percentage_200d")]
        public decimal? PriceChangePercentage200d { get; set; }

        [JsonProperty("price_change_percentage_1y")]
        public decimal? PriceChangePercentage1y { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public decimal? MarketCapChange24h { get; set; }

        [JsonProperty("market_cap_change_percentage_24h")]
        public decimal? MarketCapChangePercentage24h { get; set; }

        [JsonProperty("price_change_24h_in_currency")]
        public Price_Change_24H_In_Currency? PriceChange24hInCurrency { get; set; }

        [JsonProperty("price_change_percentage_1h_in_currency")]
        public Price_Change_Percentage_1H_In_Currency? PriceChangePercentage1hInCurrency { get; set; }

        [JsonProperty("price_change_percentage_24h_in_currency")]
        public Price_Change_Percentage_24H_In_Currency? PriceChangePercentage24hInCurrency { get; set; }

        [JsonProperty("price_change_percentage_7d_in_currency")]
        public Price_Change_Percentage_7D_In_Currency? PriceChangePercentage7dInCurrency { get; set; }

        [JsonProperty("price_change_percentage_14d_in_currency")]
        public Price_Change_Percentage_14D_In_Currency? PriceChangePercentage14dInCurrency { get; set; }

        [JsonProperty("price_change_percentage_30d_in_currency")]
        public Price_Change_Percentage_30D_In_Currency? PriceChangePercentage30dInCurrency { get; set; }

        [JsonProperty("price_change_percentage_60d_in_currency")]
        public Price_Change_Percentage_60D_In_Currency? PriceChangePercentage60dInCurrency { get; set; }

        [JsonProperty("price_change_percentage_200d_in_currency")]
        public Price_Change_Percentage_200D_In_Currency? PriceChangePercentage200dInCurrency { get; set; }

        [JsonProperty("price_change_percentage_1y_in_currency")]
        public Price_Change_Percentage_1Y_In_Currency? PriceChangePercentage1yInCurrency { get; set; }

        [JsonProperty("market_cap_change_24h_in_currency")]
        public Market_Cap_Change_24H_In_Currency? MarketCapChange24hInCurrency { get; set; }

        [JsonProperty("market_cap_change_percentage_24h_in_currency")]
        public Market_Cap_Change_Percentage_24H_In_Currency? MarketCapChangePercentage24hInCurrency { get; set; }

        public decimal? TotalSupply { get; set; }
        public decimal? MaxSupply { get; set; }
        public bool? MaxSupplyInfinite { get; set; }
        public decimal? CirculatingSupply { get; set; }
        public DateTime? LastUpdated { get; set; }
    }

    public class Ticker
    {
        public string? Base { get; set; }
        public string? Target { get; set; }
        public Market? Market { get; set; }
        public decimal? Last { get; set; }
        public decimal? Volume { get; set; }
        public ConvertedLast? ConvertedLast { get; set; }
        public ConvertedVolume? ConvertedVolume { get; set; }
        public string? TrustScore { get; set; }
        public decimal? BidAskSpreadPercentage { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? LastTradedAt { get; set; }
        public DateTime? LastFetchAt { get; set; }
        public bool? IsAnomaly { get; set; }
        public bool? IsStale { get; set; }
        public string? TradeUrl { get; set; }
        public string? TokenInfoUrl { get; set; }
        public string? CoinId { get; set; }
        public string? TargetCoinId { get; set; }
    }

    public class Market
    {
        public string? Name { get; set; }
        public string? Identifier { get; set; }
        public bool HasTradingIncentive { get; set; }
    }

    public class ConvertedLast
    {
        public decimal? Btc { get; set; }
        public decimal? Eth { get; set; }
        public decimal? Usd { get; set; }
    }

    public class ConvertedVolume
    {
        public decimal? Btc { get; set; }
        public decimal? Eth { get; set; }
        public decimal? Usd { get; set; }
    }

    public class Current_Price
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Ath
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Ath_Change_Percentage
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Ath_Date
    {
        public DateTime? aed { get; set; }
        public DateTime? ars { get; set; }
        public DateTime? aud { get; set; }
        public DateTime? bch { get; set; }
        public DateTime? bdt { get; set; }
        public DateTime? bhd { get; set; }
        public DateTime? bmd { get; set; }
        public DateTime? bnb { get; set; }
        public DateTime? brl { get; set; }
        public DateTime? btc { get; set; }
        public DateTime? cad { get; set; }
        public DateTime? chf { get; set; }
        public DateTime? clp { get; set; }
        public DateTime? cny { get; set; }
        public DateTime? czk { get; set; }
        public DateTime? dkk { get; set; }
        public DateTime? dot { get; set; }
        public DateTime? eos { get; set; }
        public DateTime? eth { get; set; }
        public DateTime? eur { get; set; }
        public DateTime? gbp { get; set; }
        public DateTime? gel { get; set; }
        public DateTime? hkd { get; set; }
        public DateTime? huf { get; set; }
        public DateTime? idr { get; set; }
        public DateTime? ils { get; set; }
        public DateTime? inr { get; set; }
        public DateTime? jpy { get; set; }
        public DateTime? krw { get; set; }
        public DateTime? kwd { get; set; }
        public DateTime? lkr { get; set; }
        public DateTime? ltc { get; set; }
        public DateTime? mmk { get; set; }
        public DateTime? mxn { get; set; }
        public DateTime? myr { get; set; }
        public DateTime? ngn { get; set; }
        public DateTime? nok { get; set; }
        public DateTime? nzd { get; set; }
        public DateTime? php { get; set; }
        public DateTime? pkr { get; set; }
        public DateTime? pln { get; set; }
        public DateTime? rub { get; set; }
        public DateTime? sar { get; set; }
        public DateTime? sek { get; set; }
        public DateTime? sgd { get; set; }
        public DateTime? sol { get; set; }
        public DateTime? thb { get; set; }
        public DateTime? _try { get; set; }
        public DateTime? twd { get; set; }
        public DateTime? uah { get; set; }
        public DateTime? usd { get; set; }
        public DateTime? vef { get; set; }
        public DateTime? vnd { get; set; }
        public DateTime? xag { get; set; }
        public DateTime? xau { get; set; }
        public DateTime? xdr { get; set; }
        public DateTime? xlm { get; set; }
        public DateTime? xrp { get; set; }
        public DateTime? yfi { get; set; }
        public DateTime? zar { get; set; }
        public DateTime? bits { get; set; }
        public DateTime? link { get; set; }
        public DateTime? sats { get; set; }
    }

    public class Atl
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Atl_Change_Percentage
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Atl_Date
    {
        public DateTime? aed { get; set; }
        public DateTime? ars { get; set; }
        public DateTime? aud { get; set; }
        public DateTime? bch { get; set; }
        public DateTime? bdt { get; set; }
        public DateTime? bhd { get; set; }
        public DateTime? bmd { get; set; }
        public DateTime? bnb { get; set; }
        public DateTime? brl { get; set; }
        public DateTime? btc { get; set; }
        public DateTime? cad { get; set; }
        public DateTime? chf { get; set; }
        public DateTime? clp { get; set; }
        public DateTime? cny { get; set; }
        public DateTime? czk { get; set; }
        public DateTime? dkk { get; set; }
        public DateTime? dot { get; set; }
        public DateTime? eos { get; set; }
        public DateTime? eth { get; set; }
        public DateTime? eur { get; set; }
        public DateTime? gbp { get; set; }
        public DateTime? gel { get; set; }
        public DateTime? hkd { get; set; }
        public DateTime? huf { get; set; }
        public DateTime? idr { get; set; }
        public DateTime? ils { get; set; }
        public DateTime? inr { get; set; }
        public DateTime? jpy { get; set; }
        public DateTime? krw { get; set; }
        public DateTime? kwd { get; set; }
        public DateTime? lkr { get; set; }
        public DateTime? ltc { get; set; }
        public DateTime? mmk { get; set; }
        public DateTime? mxn { get; set; }
        public DateTime? myr { get; set; }
        public DateTime? ngn { get; set; }
        public DateTime? nok { get; set; }
        public DateTime? nzd { get; set; }
        public DateTime? php { get; set; }
        public DateTime? pkr { get; set; }
        public DateTime? pln { get; set; }
        public DateTime? rub { get; set; }
        public DateTime? sar { get; set; }
        public DateTime? sek { get; set; }
        public DateTime? sgd { get; set; }
        public DateTime? sol { get; set; }
        public DateTime? thb { get; set; }
        public DateTime? _try { get; set; }
        public DateTime? twd { get; set; }
        public DateTime? uah { get; set; }
        public DateTime? usd { get; set; }
        public DateTime? vef { get; set; }
        public DateTime? vnd { get; set; }
        public DateTime? xag { get; set; }
        public DateTime? xau { get; set; }
        public DateTime? xdr { get; set; }
        public DateTime? xlm { get; set; }
        public DateTime? xrp { get; set; }
        public DateTime? yfi { get; set; }
        public DateTime? zar { get; set; }
        public DateTime? bits { get; set; }
        public DateTime? link { get; set; }
        public DateTime? sats { get; set; }
    }

    public class Market_Cap
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Fully_Diluted_Valuation
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Total_Volume
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class High_24H
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Low_24H
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_24H_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_1H_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_24H_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_7D_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_14D_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_30D_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_60D_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_200D_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Price_Change_Percentage_1Y_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Market_Cap_Change_24H_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }

    public class Market_Cap_Change_Percentage_24H_In_Currency
    {
        public decimal? aed { get; set; }
        public decimal? ars { get; set; }
        public decimal? aud { get; set; }
        public decimal? bch { get; set; }
        public decimal? bdt { get; set; }
        public decimal? bhd { get; set; }
        public decimal? bmd { get; set; }
        public decimal? bnb { get; set; }
        public decimal? brl { get; set; }
        public decimal? btc { get; set; }
        public decimal? cad { get; set; }
        public decimal? chf { get; set; }
        public decimal? clp { get; set; }
        public decimal? cny { get; set; }
        public decimal? czk { get; set; }
        public decimal? dkk { get; set; }
        public decimal? dot { get; set; }
        public decimal? eos { get; set; }
        public decimal? eth { get; set; }
        public decimal? eur { get; set; }
        public decimal? gbp { get; set; }
        public decimal? gel { get; set; }
        public decimal? hkd { get; set; }
        public decimal? huf { get; set; }
        public decimal? idr { get; set; }
        public decimal? ils { get; set; }
        public decimal? inr { get; set; }
        public decimal? jpy { get; set; }
        public decimal? krw { get; set; }
        public decimal? kwd { get; set; }
        public decimal? lkr { get; set; }
        public decimal? ltc { get; set; }
        public decimal? mmk { get; set; }
        public decimal? mxn { get; set; }
        public decimal? myr { get; set; }
        public decimal? ngn { get; set; }
        public decimal? nok { get; set; }
        public decimal? nzd { get; set; }
        public decimal? php { get; set; }
        public decimal? pkr { get; set; }
        public decimal? pln { get; set; }
        public decimal? rub { get; set; }
        public decimal? sar { get; set; }
        public decimal? sek { get; set; }
        public decimal? sgd { get; set; }
        public decimal? sol { get; set; }
        public decimal? thb { get; set; }
        public decimal? _try { get; set; }
        public decimal? twd { get; set; }
        public decimal? uah { get; set; }
        public decimal? usd { get; set; }
        public decimal? vef { get; set; }
        public decimal? vnd { get; set; }
        public decimal? xag { get; set; }
        public decimal? xau { get; set; }
        public decimal? xdr { get; set; }
        public decimal? xlm { get; set; }
        public decimal? xrp { get; set; }
        public decimal? yfi { get; set; }
        public decimal? zar { get; set; }
        public decimal? bits { get; set; }
        public decimal? link { get; set; }
        public decimal? sats { get; set; }
    }
}
