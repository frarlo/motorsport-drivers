using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Commands
{
    public class LoadMotorsportDriversCommand : AsyncCommandBase
    {
        private readonly MotorsportDriversStore _motorsportDriversStore;

        public LoadMotorsportDriversCommand(MotorsportDriversStore motorsportDriversStore)
        {
            _motorsportDriversStore = motorsportDriversStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            // TODO - Proper error handling
            try
            {
                await _motorsportDriversStore.Load();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
