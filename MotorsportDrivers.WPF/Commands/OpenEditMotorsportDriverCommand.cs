using MotorsportDrivers.WPF.Models;
using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Commands
{
    public class OpenEditMotorsportDriverCommand : CommandBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly MotorsportDriversListingItemViewModel _motorsportDriversListingItemViewModel;
        private readonly MotorsportDriversStore _motorsportDriversStore;

        public OpenEditMotorsportDriverCommand(
            MotorsportDriversListingItemViewModel motorsportDriversListingItemViewModel,
            MotorsportDriversStore motorsportDriversStore,
            ModalNavigationStore modalNavigationStore)
        {
            _motorsportDriversListingItemViewModel = motorsportDriversListingItemViewModel;
            _motorsportDriversStore = motorsportDriversStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            MotorsportDriver motorsportDriver = _motorsportDriversListingItemViewModel.MotorsportDriver;


            EditMotorsportDriverViewModel editMotorsportDriverViewModel = new EditMotorsportDriverViewModel(motorsportDriver, _motorsportDriversStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = editMotorsportDriverViewModel;
        }

    }
}
