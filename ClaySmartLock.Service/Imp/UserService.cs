using ClaySmartLock.Model.DTO;
using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    public class UserService : IUserService
    {
        public UserInfoDTO GetAuthenticatedUser()
        {
            // TODO
            UserInfoDTO userInfoDTO = new UserInfoDTO();
            userInfoDTO.ID = 1;
            userInfoDTO.Name = "Yusuf";
            userInfoDTO.Surname = "Öndersever";
            userInfoDTO.Username = "yondersever";
            return userInfoDTO;
        }
    }
}
