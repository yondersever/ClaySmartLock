using ClaySmartLock.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Service.User
{
    public class AuthenticateUserServiceResponse
    {
        public UserInfoDTO UserInfo { get; set; }
        public string Token { get; set; }
    }
}
