using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class DoorHistoryRepository : CoreRepository<DoorHistory, ClaySmartLockDBContext>
    {
        public DoorHistoryRepository(ClaySmartLockDBContext context) : base(context)
        {
        }

        public async Task<List<DoorHistory>> GetByDoorID(long doorID)
        {
            return await context.Set<DoorHistory>().Where(e => e.DoorID == doorID).ToListAsync();
        }
    }
}
