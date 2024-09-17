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
        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedMotorsportDriverStore = new SelectedMotorsportDriverStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MotorsportDriversViewModel motorsportDriversViewModel = new MotorsportDriversViewModel(_selectedMotorsportDriverStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, motorsportDriversViewModel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
