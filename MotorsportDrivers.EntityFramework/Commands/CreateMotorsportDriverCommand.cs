using Microsoft.EntityFrameworkCore;
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
    public class CreateMotorsportDriverCommand : ICreateMotorsportDriverCommand
    {

        private readonly MotorsportDriversDbContextFactory _contextFactory;

        public CreateMotorsportDriverCommand(MotorsportDriversDbContextFactory contextFactory)
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

                context.MotorsportDrivers.Add(motorsportDriverDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
