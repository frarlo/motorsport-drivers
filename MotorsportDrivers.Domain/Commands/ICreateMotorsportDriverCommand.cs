﻿using MotorsportDrivers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.Domain.Commands
{
    public interface ICreateMotorsportDriverCommand
    {

        Task Execute(MotorsportDriver motorsportDriver);
    }
}
