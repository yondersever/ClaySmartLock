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
        DoorIOTClientLockResponse LockDoor(DoorIOTClientLockRequest request);
        DoorIOTClientUnLockResponse UnLockDoor(DoorIOTClientUnLockRequest request);
    }
}
