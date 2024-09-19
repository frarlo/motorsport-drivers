using MotorsportDrivers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Stores
{
    public class MotorsportDriversStore
    {
        public event Action<MotorsportDriver> MotorsportDriverCreatedEvent;
        public event Action<MotorsportDriver> MotorsportDriverUpdatedEvent;

        public async Task Create(MotorsportDriver motorsportDriver)
        {
            MotorsportDriverCreatedEvent?.Invoke(motorsportDriver);
        }

        public async Task Update(MotorsportDriver motorsportDriver)
        {
            MotorsportDriverUpdatedEvent?.Invoke(motorsportDriver);
        }
    }
}
