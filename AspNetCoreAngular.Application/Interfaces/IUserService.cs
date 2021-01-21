using AspNetCoreAngular.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();

        bool Post(UserViewModel userViewModel);

        UserViewModel GetById(string id);

        bool Put(UserViewModel userViewModel);

        bool Delete(string id);
    }
}
