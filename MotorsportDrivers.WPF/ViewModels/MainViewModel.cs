using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;

        public MotorsportDriversViewModel MotorsportDriversViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, MotorsportDriversViewModel motorsportDriversViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            MotorsportDriversViewModel = motorsportDriversViewModel;
        }

    }
}
