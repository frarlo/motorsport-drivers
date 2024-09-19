using MotorsportDrivers.Domain.Commands;
using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Stores
{
    public class MotorsportDriversStore
    {
        private readonly IGetAllMotorsportDriversQuery _getAllMotorsportDriversQuery;
        private readonly ICreateMotorsportDriverCommand _createMotorsportDriverCommand;
        private readonly IUpdateMotorsportDriverCommand _updateMotorsportDriverCommand;
        private readonly IDeleteMotorsportDriverCommand _deleteMotorsportDriverCommand;

        public MotorsportDriversStore(
            IGetAllMotorsportDriversQuery getAllMotorsportDriversQuery,
            ICreateMotorsportDriverCommand createMotorsportDriverCommand,
            IUpdateMotorsportDriverCommand updateMotorsportDriverCommand,
            IDeleteMotorsportDriverCommand deleteMotorsportDriverCommand)
        {
            _getAllMotorsportDriversQuery = getAllMotorsportDriversQuery;
            _createMotorsportDriverCommand = createMotorsportDriverCommand;
            _updateMotorsportDriverCommand = updateMotorsportDriverCommand;
            _deleteMotorsportDriverCommand = deleteMotorsportDriverCommand;
        }

        public event Action<MotorsportDriver> MotorsportDriverCreatedEvent;
        public event Action<MotorsportDriver> MotorsportDriverUpdatedEvent;

        public async Task Create(MotorsportDriver motorsportDriver)
        {
            await _createMotorsportDriverCommand.Execute(motorsportDriver);

            MotorsportDriverCreatedEvent?.Invoke(motorsportDriver);
        }

        public async Task Update(MotorsportDriver motorsportDriver)
        {
            await _updateMotorsportDriverCommand.Execute(motorsportDriver);

            MotorsportDriverUpdatedEvent?.Invoke(motorsportDriver);
        }
    }
}
