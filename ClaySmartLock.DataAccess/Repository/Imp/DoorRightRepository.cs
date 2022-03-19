using ClaySmartLock.DataAccess.Context;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.Model.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClaySmartLock.DataAccess.Repository.Interface;

namespace ClaySmartLock.DataAccess.Repository.Imp
{
    public class DoorRightRepository : CoreRepository<DoorRight, ClaySmartLockDBContext>, IDoorRightRepository
    {
        public DoorRightRepository(ClaySmartLockDBContext context) : base(context)
        {
        }

        public async Task<List<DoorRight>> GetActiveRightsByTagsAndDoorID(List<long> tagIDList, long doorID)
        {
            return await context.Set<DoorRight>().Where(e => e.Status == StatusConstant.Active 
                                                        && tagIDList.Contains(e.TagID) 
                                                        && e.DoorID == doorID).ToListAsync();
        }
    }
}
