using MotorsportDrivers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.Domain.Queries
{
    public interface IGetAllMotorsportDriversQuery
    {

        Task<IEnumerable<MotorsportDriver>> Execute();


    }
}
