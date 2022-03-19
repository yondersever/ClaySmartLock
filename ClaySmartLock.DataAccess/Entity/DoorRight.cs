using ClaySmartLock.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Entity
{
    public class DoorRight : IEntity
    {
        public long ID { get; set; }
        public long TagID { get; set; }
        public long DoorID { get; set; }
        public int Status { get; set; }
    }
}
