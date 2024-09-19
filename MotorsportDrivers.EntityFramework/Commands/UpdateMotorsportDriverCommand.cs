using MotorsportDrivers.Domain.Commands;
using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.EntityFramework.Commands
{
    public class UpdateMotorsportDriverCommand : IUpdateMotorsportDriverCommand
    {

        private readonly MotorsportDriversDbContextFactory _contextFactory;

        public UpdateMotorsportDriverCommand(MotorsportDriversDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(MotorsportDriver motorsportDriver)
        {
            using (MotorsportDriversDbContext context = _contextFactory.Create())
            {
                MotorsportDriverDto motorsportDriverDto = new MotorsportDriverDto()
                {
                    Id = motorsportDriver.Id,
                    Name = motorsportDriver.Name,
                    IsWorldChampion = motorsportDriver.IsWorldChampion,
                    Country = motorsportDriver.Country
                };

                context.MotorsportDrivers.Update(motorsportDriverDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
