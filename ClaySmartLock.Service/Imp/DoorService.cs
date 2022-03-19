using ClaySmartLock.Model.Contract.DoorIOTClient;
using ClaySmartLock.Model.Enum;
using ClaySmartLock.Model.Service.Door;
using ClaySmartLock.Model.Service.DoorHistory;
using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    public class DoorService : IDoorService
    {
        private readonly IDoorIOTClient _doorIOTClient;
        private readonly IDoorHistoryService _doorHistoryService;
        private readonly IUserService _userService;

        public DoorService(IDoorIOTClient doorIOTClient, IDoorHistoryService doorHistoryService, IUserService userService)
        {
            _doorIOTClient = doorIOTClient;
            _doorHistoryService = doorHistoryService;
            _userService = userService;
        }
       
        public DoorUnlockServiceResponse UnLockDoor(DoorUnlockServiceRequest request)
        {
            DoorUnlockServiceResponse response = new DoorUnlockServiceResponse();

            DoorIOTClientUnLockRequest doorIOTClientUnLockRequest = new DoorIOTClientUnLockRequest
            {
                DoorID = request.DoorID
            };

            DoorIOTClientUnLockResponse doorIOTClientUnLockResponse = _doorIOTClient.UnLockDoor(doorIOTClientUnLockRequest);

            InsertHistory(request.DoorID, DoorHistoryActionEnum.UnLock);

            response.IsSuccess = true;
            return response;
        }

        public DoorLockServiceResponse LockDoor(DoorLockServiceRequest request)
        {
            DoorLockServiceResponse response = new DoorLockServiceResponse();

            DoorIOTClientLockRequest doorIOTClientLockRequest = new DoorIOTClientLockRequest
            {
                DoorID = request.DoorID
            };

            DoorIOTClientLockResponse doorIOTClientLockResponse = _doorIOTClient.LockDoor(doorIOTClientLockRequest);

            InsertHistory(request.DoorID, DoorHistoryActionEnum.Lock);

            response.IsSuccess = true;
            return response;
        }

        private void InsertHistory(long doorID, DoorHistoryActionEnum action)
        {
            InsertDoorHistoryServiceRequest insertDoorHistoryServiceRequest = new InsertDoorHistoryServiceRequest
            {
                DoorID = doorID,
                Action = action,
                UserID = _userService.GetAuthenticatedUser().ID
            };

            _doorHistoryService.InsertHistory(insertDoorHistoryServiceRequest);
        }

    }
}
