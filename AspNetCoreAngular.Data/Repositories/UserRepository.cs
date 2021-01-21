using AspNetCoreAngular.Data.Context;
using AspNetCoreAngular.Domain.Entities;
using AspNetCoreAngular.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AspNetCoreAngularContext context)
            : base(context) { }
        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        } 
    }
}
