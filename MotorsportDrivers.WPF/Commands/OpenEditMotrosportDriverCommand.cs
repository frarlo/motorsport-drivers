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
    public class OpenEditMotrosportDriverCommand : CommandBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly MotorsportDriver _motorsportDriver;

        public OpenEditMotrosportDriverCommand(MotorsportDriver motorsportDriver, ModalNavigationStore modalNavigationStore)
        {
            _motorsportDriver = motorsportDriver;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            EditMotorsportDriverViewModel editMotorsportDriverViewModel = new EditMotorsportDriverViewModel(_motorsportDriver, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = editMotorsportDriverViewModel;
        }

    }
}
