using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class DoorHistoryRepository : CoreRepository<DoorHistory, ClaySmartLockDBContext>, IDoorHistoryRepository
    {
        public DoorHistoryRepository(ClaySmartLockDBContext context) : base(context)
        {
        }

        public async Task<List<DoorHistory>> GetAllByChilds()
        {
            return await context.Set<DoorHistory>().Include(e => e.Door).ToListAsync();
        }

        public async Task<List<DoorHistory>> GetByDoorID(long doorID)
        {
            return await context.Set<DoorHistory>().Where(e => e.DoorID == doorID).Include(e => e.Door).ToListAsync();
        }
    }
}
