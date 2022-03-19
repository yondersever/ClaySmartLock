using ClaySmartLock.Model.Contract.DoorIOTClient;
using ClaySmartLock.Model.DTO;
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
       
        public async Task<DoorUnlockServiceResponse> UnLockDoor(DoorUnlockServiceRequest request)
        {
            DoorUnlockServiceResponse response = new DoorUnlockServiceResponse();

            DoorIOTClientUnLockRequest doorIOTClientUnLockRequest = new DoorIOTClientUnLockRequest
            {
                DoorID = request.DoorID
            };

            await _doorIOTClient.UnLockDoor(doorIOTClientUnLockRequest);
            await InsertHistory(request.DoorID, DoorHistoryActionEnum.UnLock);

            response.Message = "Door unlocked.";
            return response;
        }

        public async Task<DoorLockServiceResponse> LockDoor(DoorLockServiceRequest request)
        {
            DoorLockServiceResponse response = new DoorLockServiceResponse();

            DoorIOTClientLockRequest doorIOTClientLockRequest = new DoorIOTClientLockRequest
            {
                DoorID = request.DoorID
            };

            await _doorIOTClient.LockDoor(doorIOTClientLockRequest);
            await InsertHistory(request.DoorID, DoorHistoryActionEnum.Lock);

            response.Message = "Door locked.";
            return response;
        }

        private async Task InsertHistory(long doorID, DoorHistoryActionEnum action)
        {
            UserInfoDTO userInfo = _userService.GetAuthenticatedUser();

            InsertDoorHistoryServiceRequest insertDoorHistoryServiceRequest = new InsertDoorHistoryServiceRequest
            {
                DoorID = doorID,
                Action = action,
                UserID = userInfo.ID
            };

            await _doorHistoryService.InsertHistory(insertDoorHistoryServiceRequest);
        }

    }
}
