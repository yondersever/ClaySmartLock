using ClaySmartLock.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Entity
{
    public class Door : IEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
    }
}