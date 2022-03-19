using ClaySmartLock.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Contract.DoorHistory
{
    [Serializable]
    public class GetDoorHistoryResponse
    {
        public List<DoorHistoryDTO> History { get; set; }
    }
}
