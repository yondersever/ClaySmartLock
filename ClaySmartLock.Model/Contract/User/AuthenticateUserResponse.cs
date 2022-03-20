using ClaySmartLock.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Contract.User
{
    public class AuthenticateUserResponse
    {
        public UserInfoDTO UserInfo { get; set; }
        public string Token { get; set; }
    }
}
