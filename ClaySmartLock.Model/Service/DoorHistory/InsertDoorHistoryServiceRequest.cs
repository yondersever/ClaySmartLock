using ClaySmartLock.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Service.DoorHistory
{
    public class InsertDoorHistoryServiceRequest
    {
        public long UserID { get; set; }
        public long DoorID { get; set; }
        public DoorHistoryActionEnum Action { get; set; }
    }
}
