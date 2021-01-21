using AspNetCoreAngular.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}
