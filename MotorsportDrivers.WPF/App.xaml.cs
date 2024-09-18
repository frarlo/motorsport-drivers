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
        private readonly MotorsportDriversStore _motorsportDriversStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _motorsportDriversStore = new MotorsportDriversStore();
            _selectedMotorsportDriverStore = new SelectedMotorsportDriverStore(_motorsportDriversStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
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
