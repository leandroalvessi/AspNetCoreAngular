using AspNetCoreAngular.Application.AutoMapper;
using AspNetCoreAngular.Application.Services;
using AspNetCoreAngular.Application.ViewModels;
using AspNetCoreAngular.Domain.Entities;
using AspNetCoreAngular.Domain.Interfaces;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace ApsNetCoreAngular.Application.Tests.Services
{
    public class UserServicesTests
    {
        private UserService userService;
        public UserServicesTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        #region ValidatingSendingId
        [Fact]
        public void Post_SendingValidId()
        {
            var exception =  Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email/Password are required.", exception.Message);
        }
        #endregion

        #region ValidatingCorrectObjet
        [Fact]
        public void Post_SendingValidObject()
        {
            var result = userService.Post(new UserViewModel { Name = "Leandro Alves", Email = "leandro.dev@hotmail.com" });
            Assert.True(result);
        }
        [Fact]
        public void Get_ValidatingObject()
        {
            List<User> _user = new List<User>();
            _user.Add(new User { Id = Guid.NewGuid(), Name = "Leandro Alves", Email = "leandro.dev@hotmail.com", DateCreate = DateTime.Now });

            var _userRepositoty = new Mock<IUserRepository>();
            _userRepositoty.Setup(x => x.GetAll()).Returns(_user);

            var _audoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_audoMapperProfile));
            IMapper mapper = new Mapper(_configuration);    

            userService = new UserService(_userRepositoty.Object, mapper);
            var result = userService.Get();
            Assert.True(result.Count > 0);
        }
        #endregion

        #region ValidatingRequiredFields
        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => userService.Post(new UserViewModel { Name = "Leandro Alves" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }
        #endregion

    }
}
