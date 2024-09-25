using Microsoft.EntityFrameworkCore;
using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.Domain.Queries;
using MotorsportDrivers.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.EntityFramework.Queries
{
    public class GetAllMotorsportDriversQuery : IGetAllMotorsportDriversQuery
    {
        private readonly MotorsportDriversDbContextFactory _contextFactory;

        public GetAllMotorsportDriversQuery(MotorsportDriversDbContextFactory contextFactory) 
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<MotorsportDriver>> Execute()
        {

            // 'Using' allow us to dispose the context factory once we have finished working with it:
            using (MotorsportDriversDbContext context = _contextFactory.Create())
            {

                IEnumerable<MotorsportDriverDto> motorsportDriverDtos = await context.MotorsportDrivers.ToListAsync();

                return motorsportDriverDtos.Select(d => new MotorsportDriver(d.Id, d.Name, d.IsWorldChampion, d.Country));
            }
        }
    }
}
