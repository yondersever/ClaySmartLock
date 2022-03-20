using ClaySmartLock.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Entity
{
    public class User : IEntity
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }
    }
}
