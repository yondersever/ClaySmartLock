using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Model.Configuration;
using ClaySmartLock.Model.Constant;
using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Service.User;
using ClaySmartLock.Service.Imp;
using ClaySmartLock.Service.Interface;
using ClaySmartLock.Service.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClaySmartLock.Test.Service
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        public UserServiceTest()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()).CreateMapper();

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(e => e.GetByUserNameAndPassword("user1", "password")).Returns(Task.FromResult((User)null));
            userRepository.Setup(e => e.GetByUserNameAndPassword("user2", "testhash")).Returns(Task.FromResult(new User()));

            var configuration = new Mock<IOptions<ClayAppConfiguration>>();
            configuration.Setup(e => e.Value).Returns(new ClayAppConfiguration { Authentication = new AuthenticationConfiguration { TokenSecret = "00yMGXvwrA1FzQJULzS1j8BMtIiExffT", TokenExpirationSeconds = 3600 } });

            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(e => e.HttpContext.Items[AuthenticationConstant.UserContextKey]).Returns(new UserInfoDTO());

            var hashService = new Mock<IHashService>();
            hashService.Setup(e => e.HashBySha512(It.IsAny<string>())).Returns("testhash");

            _userService = new UserService(userRepository.Object, mapper, configuration.Object, httpContextAccessor.Object, hashService.Object);
        }

        [Fact]
        public void GetAuthenticatedUser_NotNull()
        {
            var result = _userService.GetAuthenticatedUser();
            Assert.NotNull(result);
        }

        [Fact]
        public void AuthenticateUser_InvalidCredentials_NullResponse()
        {
            var response = _userService.AuthenticateUser(new AuthenticateUserServiceRequest { UserName = "user1", Password="password" }).Result;
            Assert.Null(response);
        }

        [Fact]
        public void AuthenticateUser_ValidCredentials_NotNullTokenAndUser()
        {
            var response = _userService.AuthenticateUser(new AuthenticateUserServiceRequest { UserName = "user2", Password = "password" }).Result;
            Assert.NotNull(response);
            Assert.NotNull(response.UserInfo);
            Assert.NotNull(response.Token);
        }
    }
}
