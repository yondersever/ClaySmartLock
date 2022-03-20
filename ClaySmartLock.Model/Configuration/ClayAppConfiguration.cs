using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Configuration
{
    public class ClayAppConfiguration
    {
        public EndpointsConfiguration Endpoints { get; set; }
        public AuthenticationConfiguration Authentication { get; set; }
    }
}
