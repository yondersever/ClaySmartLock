using ClaySmartLock.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Service.DoorHistory
{
    public class GetDoorHistoryServiceResponse
    {
        public List<DoorHistoryDTO> History { get; set; }
    }
}
