using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Model.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class UserTagRepository : CoreRepository<UserTag, ClaySmartLockDBContext>, IUserTagRepository
    {
        public UserTagRepository(ClaySmartLockDBContext context) : base(context)
        {
        }

        public async Task<List<UserTag>> GetActiveTagsByUserID(long userID)
        {
            return await context.Set<UserTag>().Where(e => e.UserID == userID && e.Status == StatusConstant.Active).ToListAsync();
        }
    }
}
