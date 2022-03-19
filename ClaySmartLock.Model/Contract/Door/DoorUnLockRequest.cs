using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Contract
{
    [Serializable]
    public class DoorUnLockRequest
    {
        public long DoorID { get; set; }
    }
}
