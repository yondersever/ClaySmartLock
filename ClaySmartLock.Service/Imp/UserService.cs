using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Model.Configuration;
using ClaySmartLock.Model.Constant;
using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Service.User;
using ClaySmartLock.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<ClayAppConfiguration> _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHashService _hashService;

        public UserService(IUserRepository userRepository, IMapper mapper, IOptions<ClayAppConfiguration> configuration, IHttpContextAccessor httpContextAccessor, IHashService hashService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _hashService = hashService;
        }

        public UserInfoDTO GetAuthenticatedUser()
        {
            return _httpContextAccessor.HttpContext.Items[AuthenticationConstant.UserContextKey] as UserInfoDTO;
        }

        public async Task<AuthenticateUserServiceResponse> AuthenticateUser(AuthenticateUserServiceRequest request)
        {
            string hashedPassword = _hashService.HashBySha512(request.Password);
            var user = await _userRepository.GetByUserNameAndPassword(request.UserName, hashedPassword);

            if (user == null) 
                return null;

            var token = GenerateJwtToken(user);

            return new AuthenticateUserServiceResponse
            {
                Token = token,
                UserInfo = _mapper.Map<UserInfoDTO>(user)
            };
        }

        public async Task<UserInfoDTO> GetUserByID(long userID)
        {
            var user = await _userRepository.Get(userID);
            return _mapper.Map<UserInfoDTO>(user);
        }


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.Value.Authentication.TokenSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddSeconds(_configuration.Value.Authentication.TokenExpirationSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
