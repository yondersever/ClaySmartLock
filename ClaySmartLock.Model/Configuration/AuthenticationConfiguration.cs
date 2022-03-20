using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Configuration
{
    public class AuthenticationConfiguration
    {
        public string TokenSecret { get; set; }
        public double TokenExpirationSeconds { get; set; }
    }
}
