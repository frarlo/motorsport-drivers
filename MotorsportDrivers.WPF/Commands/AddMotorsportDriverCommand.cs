using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Commands
{
    public class AddMotorsportDriverCommand : AsyncCommandBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;

        public AddMotorsportDriverCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            // Add Motorsport Driver to our database.

            _modalNavigationStore.Close();
        }
    }
}
