using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversListingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<MotorsportDriversListingItemViewModel> _motorsportDriversListingItemViewModels;

        public IEnumerable<MotorsportDriversListingItemViewModel> MotorsportDriversListingItemViewModels => _motorsportDriversListingItemViewModels;

        public MotorsportDriversListingViewModel() {

            _motorsportDriversListingItemViewModels = new ObservableCollection<MotorsportDriversListingItemViewModel>();

            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel("Ayrton Senna"));
            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel("Mika Hakkinen"));
            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel("Fernando Alonso"));

        }

    }
}
