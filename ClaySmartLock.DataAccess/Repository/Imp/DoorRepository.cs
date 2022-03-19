using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class DoorRepository : CoreRepository<Door, ClaySmartLockDBContext>
    {
        public DoorRepository(ClaySmartLockDBContext context) : base(context)
        {
        }
    }
}
