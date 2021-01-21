using AspNetCoreAngular.Application.ViewModels;
using AspNetCoreAngular.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            CreateMap<UserViewModel, User>();
            #endregion

            #region DomainToViewModel
            CreateMap<User, UserViewModel>();
            #endregion
        }
    }
}
