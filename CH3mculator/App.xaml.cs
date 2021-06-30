using CH3mculator.Module.Calculator;
using CH3mculator.Shared.Logic;
using CH3mculator.Shared.Model;
using CH3mculator.Shell.ErrorHandling;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace CH3mculator.Shell
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        private Window _mainWindow;

        public App()
        {
            Current.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(HandleUnhandledException);
        }

        private void OnStartup(object sender, StartupEventArgs startUpArgs)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            AddServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var viewModel = ServiceProvider.GetService<ShellViewModel>();
            _mainWindow = new Shell() { DataContext = viewModel };
            _mainWindow.Show();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddOptions<UsersettingsOptions>().Bind(Configuration.GetSection("Usersettings"));
            services.AddTransient<Func<IOptions<UsersettingsOptions>>>(provider => () => provider.GetService<IOptions<UsersettingsOptions>>());
            services.AddSingleton<UsersettingsProvider>();
            services.AddTransient<CalculatorViewModel>();
            services.AddTransient<Calculator>();
            services.AddTransient<ShellViewModel>();
        }

        private void HandleUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            _mainWindow.Content = new ErrorView(new ErrorViewModel(e.Exception));
            e.Handled = true;
        }
    }
}
