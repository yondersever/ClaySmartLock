using ClaySmartLock.Model.Contract.DoorIOTClient;
using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Service.Door;
using ClaySmartLock.Model.Service.DoorHistory;
using ClaySmartLock.Service.Imp;
using ClaySmartLock.Service.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClaySmartLock.Test.Service
{
    public class DoorServiceTest
    {
        private readonly IDoorService _doorService;

        public DoorServiceTest()
        {
            var doorIOTClient = new Mock<IDoorIOTClient>();

            doorIOTClient.Setup(e => e.LockDoor(It.IsAny<DoorIOTClientLockRequest>())).Returns(Task.FromResult(new DoorIOTClientLockResponse()));
            doorIOTClient.Setup(e => e.LockDoor(new DoorIOTClientLockRequest { DoorID = 3 })).ThrowsAsync(new HttpRequestException());

            doorIOTClient.Setup(e => e.UnLockDoor(It.IsAny<DoorIOTClientUnLockRequest>())).Returns(Task.FromResult(new DoorIOTClientUnLockResponse()));
            doorIOTClient.Setup(e => e.UnLockDoor(new DoorIOTClientUnLockRequest { DoorID = 3 })).ThrowsAsync(new HttpRequestException());


            var doorHistoryService = new Mock<IDoorHistoryService>();
            doorHistoryService.Setup(e => e.InsertHistory(It.IsAny<InsertDoorHistoryServiceRequest>())).Returns(Task.FromResult(new DoorHistoryDTO()));

            var userService = new Mock<IUserService>();
            userService.Setup(e => e.GetAuthenticatedUser()).Returns(new UserInfoDTO());

            _doorService = new DoorService(doorIOTClient.Object, doorHistoryService.Object, userService.Object);
        }

        [Fact]
        public void UnLockDoor_Success()
        {
            var result = _doorService.UnLockDoor(new DoorUnlockServiceRequest()).Result;
            Assert.NotNull(result);
        }

        [Fact]
        public void UnLockDoor_FailIOTClient_ThrowsHttpRequestException()
        {
            Assert.ThrowsAsync<HttpRequestException>(() => _doorService.UnLockDoor(new DoorUnlockServiceRequest() { DoorID = 3 }));
        }

        [Fact]
        public void LockDoor_Success()
        {
            var result = _doorService.LockDoor(new DoorLockServiceRequest()).Result;
            Assert.NotNull(result);
        }

        [Fact]
        public void LockDoor_FailIOTClient_ThrowsHttpRequestException()
        {
            Assert.ThrowsAsync<HttpRequestException>(() => _doorService.LockDoor(new DoorLockServiceRequest() { DoorID = 3 }));
        }
    }
}
