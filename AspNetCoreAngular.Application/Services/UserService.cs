using AspNetCoreAngular.Application.Interfaces;
using AspNetCoreAngular.Application.ViewModels;
using AspNetCoreAngular.Domain.Entities;
using AspNetCoreAngular.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();
            IEnumerable <User> _user = this.userRepository.GetAll();

            _userViewModels = mapper.Map<List<UserViewModel>>(_user);

            return _userViewModels;
        }
        public bool Post(UserViewModel userViewModel)
        {
            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);
            return true;
        }
    }
}
