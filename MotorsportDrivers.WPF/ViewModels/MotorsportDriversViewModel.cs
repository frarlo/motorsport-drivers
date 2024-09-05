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

        public MotorsportDriversViewModel(SelectedMotorsportDriverStore _selectedMotorsportDriverStore)
        {
            MotorsportDriversListingViewModel = new MotorsportDriversListingViewModel(_selectedMotorsportDriverStore);

            MotorsportDriversDetailsViewModel = new MotorsportDriversDetailsViewModel(_selectedMotorsportDriverStore);    

        }

    }
}
