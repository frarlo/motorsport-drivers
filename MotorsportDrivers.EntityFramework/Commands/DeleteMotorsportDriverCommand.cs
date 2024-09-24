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
    public class DeleteMotorsportDriverCommand : IDeleteMotorsportDriverCommand
    {

        private readonly MotorsportDriversDbContextFactory _contextFactory;

        public DeleteMotorsportDriverCommand(MotorsportDriversDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (MotorsportDriversDbContext context = _contextFactory.Create())
            {

                MotorsportDriverDto motorsportDriverDto = new MotorsportDriverDto()
                {
                    Id = id
                };

                context.MotorsportDrivers.Remove(motorsportDriverDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
