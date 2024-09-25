using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Commands
{
    public class EditMotorsportDriverCommand : AsyncCommandBase
    {
        private readonly EditMotorsportDriverViewModel _editMotorsportDriverViewModel;
        private readonly MotorsportDriversStore _motorsportDriversStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditMotorsportDriverCommand(
            EditMotorsportDriverViewModel editMotorsportDriverViewModel,
            MotorsportDriversStore motorsportDriversStore,
            ModalNavigationStore modalNavigationStore)
        {
            _editMotorsportDriverViewModel = editMotorsportDriverViewModel;
            _motorsportDriversStore = motorsportDriversStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {

            MotorsportDriverDetailsFormViewModel formViewModel = _editMotorsportDriverViewModel.MotorsportDriverDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;

            MotorsportDriver motorsportDriver = new MotorsportDriver(
                _editMotorsportDriverViewModel.MotorsportDriverId,
                formViewModel.Name,
                formViewModel.IsWorldChampion,
                formViewModel.Country);

            try
            {

                await _motorsportDriversStore.Update(motorsportDriver);

                _modalNavigationStore.Close();
            }
            catch (Exception ex)
            {
                formViewModel.ErrorMessage = "Failed to update Motorsport driver. Please, try again later.";
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }

            _modalNavigationStore.Close();
        }
    }
}
