﻿using AspNetCoreAngular.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
