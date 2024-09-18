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
    public class AddMotorsportDriverCommand : AsyncCommandBase
    {
        private readonly AddMotorsportDriverViewModel _addMotorsportDriverViewModel;
        private readonly MotorsportDriversStore _motorsportDriversStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddMotorsportDriverCommand(AddMotorsportDriverViewModel addMotorsportDriverViewModel, MotorsportDriversStore motorsportDriversStore, ModalNavigationStore modalNavigationStore)
        {
            _addMotorsportDriverViewModel = addMotorsportDriverViewModel;
            _motorsportDriversStore = motorsportDriversStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {

            MotorsportDriverDetailsFormViewModel formViewModel = _addMotorsportDriverViewModel.MotorsportDriverDetailsFormViewModel;

            MotorsportDriver motorsportDriver = new MotorsportDriver(
                Guid.NewGuid(),
                formViewModel.Name,
                formViewModel.IsWorldChampion,
                formViewModel.Country);

            // TODO - Exception control pending.
            try
            {
                await _motorsportDriversStore.Create(motorsportDriver);

                _modalNavigationStore.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
