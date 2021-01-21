using AspNetCoreAngular.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
