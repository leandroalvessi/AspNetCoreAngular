using AspNetCoreAngular.Application.Interfaces;
using AspNetCoreAngular.Application.ViewModels;
using AspNetCoreAngular.Auth.Services;
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

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not found");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            _user = mapper.Map<User>(userViewModel);
            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete (string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not found");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            return this.userRepository.Delete(_user);

        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            User _user = this.userRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == user.Email.ToLower());
            if (_user == null)
                throw new Exception("User not found");

            return new UserAuthenticateResponseViewModel(mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));
        }
    }
}
