using ClaySmartLock.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Entity
{
    public class UserTag : IEntity
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public string Tag { get; set; }
        public int Status { get; set; }
    }
}
