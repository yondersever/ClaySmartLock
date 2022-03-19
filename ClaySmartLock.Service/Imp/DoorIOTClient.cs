using ClaySmartLock.Model.Contract.DoorIOTClient;
using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    // Mock client
    public class DoorIOTClient : IDoorIOTClient
    {
        public DoorIOTClientLockResponse LockDoor(DoorIOTClientLockRequest request)
        {
            DoorIOTClientLockResponse response = new DoorIOTClientLockResponse();
            response.Message = "Door Locked.";
            return response;
        }

        public DoorIOTClientUnLockResponse UnLockDoor(DoorIOTClientUnLockRequest request)
        {
            DoorIOTClientUnLockResponse response = new DoorIOTClientUnLockResponse();
            response.Message = "Door Unlocked.";
            return response;
        }
    }
}
