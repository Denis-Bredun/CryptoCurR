using CryptoCurR.Interfaces;
using CryptoCurR.Services;
using CryptoCurR.ViewModels;
using CryptoCurR.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace CryptoCurR
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        private IHost _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureLogger();

            _host = CreateHostBuilder().Build();
            Services = _host.Services;

            ShowMainWindow();

            base.OnStartup(e);
        }

        private void ShowMainWindow()
        {
            var mainWindow = Services.GetRequiredService<MainPage>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var notifier = Services.GetService<Notifier>();
            notifier?.Dispose();

            Log.CloseAndFlush();
            base.OnExit(e);
        }

        private void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs\\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .UseSerilog()
                .ConfigureServices((context, services) =>
                {
                    RegisterServices(services);
                });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddScoped<ICoinGeckoClient, CoinGeckoClient>();
            services.AddScoped<ICoinGeckoParser, CoinGeckoParser>();
            services.AddScoped<INetworkCheckService, NetworkCheckService>();
            services.AddScoped<IErrorHandler, ErrorHandler>();
            services.AddScoped<ICoinGeckoService, CoinGeckoService>();
            services.AddScoped<ICryptoListService, CryptoListService>();
            services.AddScoped<ICoinDetailsMapper, CoinDetailsMapper>();
            services.AddScoped<ICoinDetailsLoader, CoinDetailsLoader>();

            services.AddSingleton(CreateNotifier);
            services.AddScoped<MainPage>();
            services.AddScoped<MainPageViewModel>();
            services.AddScoped<CoinDetailsViewModel>();
        }

        private Notifier CreateNotifier(IServiceProvider provider)
        {
            return new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Current.MainWindow,
                    corner: Corner.BottomCenter,
                    offsetX: 0,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Current.Dispatcher;
            });
        }
    }
}
