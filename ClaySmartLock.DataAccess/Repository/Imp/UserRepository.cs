using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Model.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class UserRepository : CoreRepository<User, ClaySmartLockDBContext>, IUserRepository
    {
        public UserRepository(ClaySmartLockDBContext context) : base(context)
        {
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string password)
        {
            return await context.Set<User>().Where(e => e.Username == userName 
            && e.Status == StatusConstant.Active 
            && e.Password == password).FirstOrDefaultAsync();
        }
    }
}
