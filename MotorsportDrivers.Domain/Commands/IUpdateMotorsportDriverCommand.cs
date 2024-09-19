using MotorsportDrivers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.Domain.Commands
{
    public interface IUpdateMotorsportDriverCommand
    {
        Task Execute(MotorsportDriver motorsportDriver);

    }
}
