using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversViewModel : ViewModelBase
    {

        public MotorsportDriversListingViewModel MotorsportDriversListingViewModel {  get; }

        public MotorsportDriversDetailsViewModel MotorsportDriversDetailsViewModel { get; }

        public ICommand AddMotorsportDriversCommand { get; }

        public MotorsportDriversViewModel(MotorsportDriversStore motorsportDriversStore, SelectedMotorsportDriverStore selectedMotorsportDriverStore, ModalNavigationStore modalNavigationStore)
        {
            MotorsportDriversListingViewModel = new MotorsportDriversListingViewModel(motorsportDriversStore, selectedMotorsportDriverStore, modalNavigationStore);

            MotorsportDriversDetailsViewModel = new MotorsportDriversDetailsViewModel(selectedMotorsportDriverStore);

            AddMotorsportDriversCommand = new OpenAddMotorsportDriverCommand(motorsportDriversStore, modalNavigationStore);

        }

    }
}
