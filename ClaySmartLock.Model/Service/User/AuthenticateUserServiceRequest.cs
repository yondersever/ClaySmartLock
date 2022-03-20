using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Service.User
{
    public class AuthenticateUserServiceRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
