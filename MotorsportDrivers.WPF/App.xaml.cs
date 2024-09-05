using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MotorsportDrivers.WPF
{

    public partial class App : Application
    {

        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;

        public App()
        {
            _selectedMotorsportDriverStore = new SelectedMotorsportDriverStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MotorsportDriversViewModel(_selectedMotorsportDriverStore)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
