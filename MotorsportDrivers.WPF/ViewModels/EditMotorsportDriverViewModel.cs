using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.WPF.Models;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class EditMotorsportDriverViewModel : ViewModelBase
    {
        public Guid MotorsportDriverId { get; }
        public MotorsportDriverDetailsFormViewModel MotorsportDriverDetailsFormViewModel { get; }

        public EditMotorsportDriverViewModel(MotorsportDriver motorsportDriver, MotorsportDriversStore motorsportDriversStore, ModalNavigationStore modalNavigationStore)
        {
            MotorsportDriverId = motorsportDriver.Id;

            ICommand editCommand = new EditMotorsportDriverCommand(this, motorsportDriversStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            MotorsportDriverDetailsFormViewModel = new MotorsportDriverDetailsFormViewModel(editCommand, cancelCommand)
            {
                Name = motorsportDriver.Name,
                IsWorldChampion = motorsportDriver.IsWorldChampion,
                Country = motorsportDriver.Country
            };
        }
    }
}
