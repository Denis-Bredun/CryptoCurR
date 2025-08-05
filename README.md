# CryptoCurR

A modern cryptocurrency desktop application built with WPF (.NET 8.0), featuring real-time cryptocurrency data, detailed coin analytics, interactive charts, and currency conversion capabilities. The application integrates with the CoinGecko API to provide comprehensive cryptocurrency market information.

## Features

### Core Functionality
- **Cryptocurrency Market Data**: Real-time display of top cryptocurrencies with current prices, market cap, and 24h changes
- **Advanced Search**: Search for specific cryptocurrencies with instant results
- **Detailed Coin Analytics**: Comprehensive coin details including market data, price history, and trading information
- **Interactive Charts**: Line charts and candlestick charts with multiple timeframe options (1d, 7d, 30d)
- **Currency Converter**: Convert between different cryptocurrencies with real-time exchange rates

## Prerequisites

Before running this project, ensure you have the following installed:

- **Visual Studio 2022** (Community, Professional, or Enterprise)
- **.NET desktop development** (workload from Visual Studio 2022 Installer; includes WPF)
- **Git** (for cloning the repository)
- **Internet connection** (required for CoinGecko API access)

## Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd CryptoCurR
   ```

2. **Open the solution in Visual Studio 2022**
   - Open `CryptoCurR.sln` in Visual Studio 2022
   - Wait for the solution to load and restore NuGet packages

3. **Verify dependencies**
   - Ensure all NuGet packages are restored
   - Check that the solution builds successfully (Build → Build Solution)

## API Integration

### CoinGecko API

The application integrates with the **CoinGecko API** - a comprehensive cryptocurrency data API that provides real-time market data, historical prices, and detailed coin information.

**API Base URL**: `https://api.coingecko.com/api/v3`

### Available Endpoints

The application utilizes the following CoinGecko API endpoints:

#### Market Data
- **`/coins/markets`** - Get top cryptocurrencies by market cap
  - Parameters: `vs_currency`, `order`, `per_page`, `page`
  - Used for: Main page cryptocurrency list display

#### Coin Information
- **`/coins/{id}`** - Get detailed information about a specific coin
  - Parameters: `id` (coin identifier)
  - Used for: Coin details page with comprehensive market data

#### Search Functionality
- **`/search?query={query}`** - Search for cryptocurrencies
  - Parameters: `query` (search term)
  - Used for: Finding specific cryptocurrencies by name or symbol

#### Historical Data
- **`/coins/{id}/market_chart`** - Get historical market data
  - Parameters: `id`, `vs_currency`, `days`
  - Used for: Line charts showing price history over time

#### OHLC Data (Candlestick Charts)
- **`/coins/{id}/ohlc`** - Get Open/High/Low/Close data
  - Parameters: `id`, `vs_currency`, `days`
  - Used for: Candlestick charts with detailed price movements

#### Trading Information
- **`/coins/{id}/tickers`** - Get trading data from various exchanges
  - Parameters: `id` (coin identifier)
  - Used for: Exchange trading information and market spread

#### Price Conversion
- **`/simple/price`** - Get simple price conversion rates
  - Parameters: `ids`, `vs_currencies`, `precision`
  - Used for: Currency converter functionality

### Rate Limiting

**Important**: The CoinGecko API has rate limits of 5-15 calls per minute in the free version, with higher limits available in paid plans.

### Data Currency

All price data is provided in **USD** by default, with support for other fiat currencies through the `vs_currency` parameter.

## Running the Application

### Local Development

1. **Set the startup project**
   - Right-click on `CryptoCurR` in Solution Explorer
   - Select "Set as Startup Project"

2. **Run the application**
   - Press `F5` or click the "Start" button in Visual Studio
   - The application will launch as a desktop WPF application

3. **Using the application**
   - **Main Page**: View top cryptocurrencies, search, and navigate to other features
   - **Coin Details**: Double-click any coin to view detailed information and charts
   - **Currency Converter**: Click "Currency Converter" button to convert between cryptocurrencies

## Testing

The project includes comprehensive integrated testing:

### Running Tests
1. Open Test Explorer in Visual Studio (Test → Test Explorer)
2. Build the solution
3. Run tests from Test Explorer or use command line:
   ```bash
   dotnet test
   ```

## Troubleshooting

### Common Issues

1. **API Rate Limiting**
   - CoinGecko API has rate limits
   - Application includes error handling for rate limit responses
   - Consider implementing request throttling for production use

2. **Network Connectivity**
   - Application requires internet connection for API access
   - Network status is monitored and reported to users
   - Offline mode is not supported

3. **Build Errors**
   - Ensure .NET 8.0 SDK is installed
   - Restore NuGet packages
   - Clean and rebuild the solution

4. **Chart Display Issues**
   - Verify LiveCharts.Wpf package is properly installed
   - Check data format for chart series
   - Ensure proper data binding in XAML

### Getting Help

If you encounter issues:
1. Check the application logs in the `logs/` directory
2. Review the console output for error messages
3. Verify all prerequisites are installed correctly
4. Ensure stable internet connection for API access

## License

This project is licensed under the terms specified in the LICENSE.txt file.