using Microsoft.EntityFrameworkCore;
using MotorsportDrivers.Domain.Commands;
using MotorsportDrivers.Domain.Queries;
using MotorsportDrivers.EntityFramework;
using MotorsportDrivers.EntityFramework.Commands;
using MotorsportDrivers.EntityFramework.Queries;
using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MotorsportDrivers.WPF
{

    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly MotorsportDriversDbContextFactory _motorsportDriversDbContextFactory;
        private readonly IGetAllMotorsportDriversQuery _getAllMotorsportDriversQuery;
        private readonly ICreateMotorsportDriverCommand _createMotorsportDriverCommand;
        private readonly IUpdateMotorsportDriverCommand _updateMotorsportDriverCommand;
        private readonly IDeleteMotorsportDriverCommand _deleteMotorsportDriverCommand;
        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;
        private readonly MotorsportDriversStore _motorsportDriversStore;

        public App()
        {
            string connectionString = "Data Source=MotorsportDrivers.db";

            _modalNavigationStore = new ModalNavigationStore();
            _motorsportDriversDbContextFactory = new MotorsportDriversDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            _getAllMotorsportDriversQuery = new GetAllMotorsportDriversQuery(_motorsportDriversDbContextFactory);
            _createMotorsportDriverCommand = new CreateMotorsportDriverCommand(_motorsportDriversDbContextFactory);
            _updateMotorsportDriverCommand = new UpdateMotorsportDriverCommand(_motorsportDriversDbContextFactory);
            _deleteMotorsportDriverCommand = new DeleteMotorsportDriverCommand(_motorsportDriversDbContextFactory);
            _motorsportDriversStore = new MotorsportDriversStore(
                _getAllMotorsportDriversQuery,
                _createMotorsportDriverCommand,
                _updateMotorsportDriverCommand,
                _deleteMotorsportDriverCommand);
            _selectedMotorsportDriverStore = new SelectedMotorsportDriverStore(_motorsportDriversStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            using (MotorsportDriversDbContext context = _motorsportDriversDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            MotorsportDriversViewModel motorsportDriversViewModel = new MotorsportDriversViewModel(
                _motorsportDriversStore,
                _selectedMotorsportDriverStore,
                _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, motorsportDriversViewModel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
