using AspNetCoreAngular.Application.Interfaces;
using AspNetCoreAngular.Application.ViewModels;
using AspNetCoreAngular.Domain.Entities;
using AspNetCoreAngular.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();
            IEnumerable <User> _user = this.userRepository.GetAll();

            foreach (var item in _user)
                _userViewModels.Add(new UserViewModel { Id = item.Id, Nome = item.Name, Email = item.Email});

            return _userViewModels;
        }
        public bool Post(UserViewModel userViewModel)
        {
            User _user = new User
            {
                Id = Guid.NewGuid(),
                Email = userViewModel.Email,
                Name = userViewModel.Nome
            };

            this.userRepository.Create(_user);
            return true;
        }
    }
}
