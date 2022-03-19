using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.DTO
{
    [Serializable]
    public class DoorHistoryDTO
    {
        public long ID { get; set; }
        public long DoorID { get; set; }
        public long UserID { get; set; }
        public DateTime ActionDate { get; set; }
        public short ActionType { get; set; }
        public int Source { get; set; }
    }
}
