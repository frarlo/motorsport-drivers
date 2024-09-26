using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorsportDrivers.Domain.Commands;
using MotorsportDrivers.Domain.Queries;
using MotorsportDrivers.EntityFramework;
using MotorsportDrivers.EntityFramework.Commands;
using MotorsportDrivers.EntityFramework.Queries;
using MotorsportDrivers.WPF.HostBuilders;
using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MotorsportDrivers.WPF
{

    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IGetAllMotorsportDriversQuery, GetAllMotorsportDriversQuery>();
                    services.AddSingleton<ICreateMotorsportDriverCommand, CreateMotorsportDriverCommand>();
                    services.AddSingleton<IUpdateMotorsportDriverCommand, UpdateMotorsportDriverCommand>();
                    services.AddSingleton<IDeleteMotorsportDriverCommand, DeleteMotorsportDriverCommand>();

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<MotorsportDriversStore>();
                    services.AddSingleton<SelectedMotorsportDriverStore>();

                    services.AddTransient<MotorsportDriversViewModel>(CreateMotorsportDriversViewModel);
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });

                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MotorsportDriversDbContextFactory motorsportDriversDbContextFactory = _host.Services.GetRequiredService<MotorsportDriversDbContextFactory>();

            using (MotorsportDriversDbContext context = motorsportDriversDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private MotorsportDriversViewModel CreateMotorsportDriversViewModel(IServiceProvider services)
        {
            return MotorsportDriversViewModel.LoadViewModel(
                services.GetRequiredService<MotorsportDriversStore>(),
                services.GetRequiredService<SelectedMotorsportDriverStore>(),
                services.GetRequiredService<ModalNavigationStore>()
                );
        }
    }
}
