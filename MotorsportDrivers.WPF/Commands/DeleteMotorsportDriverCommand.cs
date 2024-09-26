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
    public class DeleteMotorsportDriverCommand : AsyncCommandBase
    {
        private readonly MotorsportDriversListingItemViewModel _motorsportDriversListingItemViewModel;
        private readonly MotorsportDriversStore _motorsportDriversStore;

        public DeleteMotorsportDriverCommand(
            MotorsportDriversListingItemViewModel motorsportDriversListingItemViewModel,
            MotorsportDriversStore motorsportDriversStore)
        {
            _motorsportDriversListingItemViewModel = motorsportDriversListingItemViewModel;
            _motorsportDriversStore = motorsportDriversStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _motorsportDriversListingItemViewModel.IsDeleting = true;
            _motorsportDriversListingItemViewModel.ErrorMessage = null;

            MotorsportDriver motorsportDriver = _motorsportDriversListingItemViewModel.MotorsportDriver;

            try
            {
                await _motorsportDriversStore.Delete(motorsportDriver.Id);
            }
            catch (Exception ex)
            {
                _motorsportDriversListingItemViewModel.ErrorMessage = "Failed to delete Motorsport driver. Please, try again later.";
            }
            finally
            {
                _motorsportDriversListingItemViewModel.IsDeleting = false;
            }

        }
    }
}

