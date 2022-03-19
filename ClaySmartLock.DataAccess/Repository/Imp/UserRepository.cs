using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class UserRepository : CoreRepository<User, ClaySmartLockDBContext>
    {
        public UserRepository(ClaySmartLockDBContext context) : base(context)
        {
        }
    }
}
