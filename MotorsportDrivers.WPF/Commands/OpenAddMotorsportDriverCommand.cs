using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.Commands
{
    public class OpenAddMotorsportDriverCommand : CommandBase
    {
        private readonly MotorsportDriversStore _motorsportDriversStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddMotorsportDriverCommand(MotorsportDriversStore motorsportDriversStore, ModalNavigationStore modalNavigationStore)
        {
            _motorsportDriversStore = motorsportDriversStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddMotorsportDriverViewModel addMotorsportDriverViewModel = new AddMotorsportDriverViewModel(_motorsportDriversStore , _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addMotorsportDriverViewModel;
        }

    }
    
}
