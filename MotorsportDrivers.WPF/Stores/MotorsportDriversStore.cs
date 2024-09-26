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
        private readonly List<MotorsportDriver> _motorsportDrivers;

        public event Action MotorsportDriversLoadedEvent;
        public event Action<MotorsportDriver> MotorsportDriverCreatedEvent;
        public event Action<MotorsportDriver> MotorsportDriverUpdatedEvent;
        public event Action<Guid> MotorsportDriverDeletedEvent;

        public IEnumerable<MotorsportDriver> MotorsportDrivers => _motorsportDrivers;

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
            _motorsportDrivers = new List<MotorsportDriver>();
        }

        public async Task Load()
        {
            IEnumerable<MotorsportDriver> motorsportDrivers = await _getAllMotorsportDriversQuery.Execute();

            _motorsportDrivers.Clear();
            _motorsportDrivers.AddRange(motorsportDrivers);

            MotorsportDriversLoadedEvent?.Invoke();
        }

        public async Task Create(MotorsportDriver motorsportDriver)
        {
            await _createMotorsportDriverCommand.Execute(motorsportDriver);

            _motorsportDrivers.Add(motorsportDriver);

            MotorsportDriverCreatedEvent?.Invoke(motorsportDriver);
        }

        public async Task Update(MotorsportDriver motorsportDriver)
        {
            await _updateMotorsportDriverCommand.Execute(motorsportDriver);

            int currentIndex = _motorsportDrivers.FindIndex(d => d.Id == motorsportDriver.Id);

            if(currentIndex != -1)
            {
                _motorsportDrivers[currentIndex] = motorsportDriver;
            }
            else
            {
                _motorsportDrivers.Add(motorsportDriver);
            }

            MotorsportDriverUpdatedEvent?.Invoke(motorsportDriver);
        }

        public async Task Delete(Guid id)
        {
            await _deleteMotorsportDriverCommand.Execute(id);

            _motorsportDrivers.RemoveAll(d => d.Id == id); 

            MotorsportDriverDeletedEvent?.Invoke(id);
        }
    }
}
