using ClaySmartLock.Model.Contract.DoorIOTClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Interface
{
    public interface IDoorIOTClient
    {
        Task<DoorIOTClientLockResponse> LockDoor(DoorIOTClientLockRequest request);
        Task<DoorIOTClientUnLockResponse> UnLockDoor(DoorIOTClientUnLockRequest request);
    }
}
