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
    public class AddMotorsportDriverViewModel : ViewModelBase
    {
        public MotorsportDriverDetailsFormViewModel MotorsportDriverDetailsFormViewModel { get; }

        public AddMotorsportDriverViewModel(MotorsportDriversStore motorsportDriversStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddMotorsportDriverCommand(this, motorsportDriversStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            MotorsportDriverDetailsFormViewModel = new MotorsportDriverDetailsFormViewModel(submitCommand, cancelCommand);
        }

    }
}
