using ClaySmartLock.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.DataAccess.Repository.Interface
{
    public interface IDoorHistoryRepository : IRepository<DoorHistory>
    {
        Task<List<DoorHistory>> GetByDoorID(long doorID);
        Task<List<DoorHistory>> GetAllByChilds();
    }
}
