using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Commands
{
    public class EditMotorsportDriverCommand : AsyncCommandBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;

        public EditMotorsportDriverCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            // Edit Motorsport Driver to our database.

            _modalNavigationStore.Close();
        }
    }
}
