﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Security
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }

    }
}
