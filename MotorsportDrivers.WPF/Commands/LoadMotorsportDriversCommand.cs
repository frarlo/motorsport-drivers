using MotorsportDrivers.WPF.Stores;
using MotorsportDrivers.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Commands
{
    public class LoadMotorsportDriversCommand : AsyncCommandBase
    {
        private readonly MotorsportDriversViewModel _motorsportDriversViewModel;
        private readonly MotorsportDriversStore _motorsportDriversStore;

        public LoadMotorsportDriversCommand(MotorsportDriversViewModel motorsportDriversViewModel, MotorsportDriversStore motorsportDriversStore)
        {
            _motorsportDriversViewModel = motorsportDriversViewModel;
            _motorsportDriversStore = motorsportDriversStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {

            _motorsportDriversViewModel.ErrorMessage = null;
            _motorsportDriversViewModel.IsLoading = true;

            try
            {
                await _motorsportDriversStore.Load();
            }
            catch (Exception ex)
            {
                _motorsportDriversViewModel.ErrorMessage = "Failed to load Motorsport drivers. Please restart the application.";
            }
            finally
            {
                _motorsportDriversViewModel.IsLoading = false;
            }
            
        }
    }
}
