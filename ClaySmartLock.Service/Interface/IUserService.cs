using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Interface
{
    public interface IUserService
    {
        UserInfoDTO GetAuthenticatedUser();

        Task<AuthenticateUserServiceResponse> AuthenticateUser(AuthenticateUserServiceRequest request);

        Task<UserInfoDTO> GetUserByID(long userID);
    }
}
