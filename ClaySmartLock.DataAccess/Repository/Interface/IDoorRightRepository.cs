using ClaySmartLock.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Interface
{
    public interface IDoorRightRepository : IRepository<DoorRight>
    {
        Task<List<DoorRight>> GetActiveRightsByTagsAndDoorID(List<long> tagIDList, long doorID);
    }
}
