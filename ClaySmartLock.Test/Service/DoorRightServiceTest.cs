using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Service.Imp;
using ClaySmartLock.Service.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClaySmartLock.Test.Service
{
    public class DoorRightServiceTest
    {
        private readonly IDoorRightService _doorRightService;


        public DoorRightServiceTest()
        {
            List<long> tagIDList = new List<long> { 1 };
            List<UserTag> tagList = new List<UserTag> { new UserTag() { ID = 1 } };

            var doorRightRepository = new Mock<IDoorRightRepository>();
            doorRightRepository.Setup(e => e.GetActiveRightsByTagsAndDoorID(tagIDList, 1)).Returns(Task.FromResult(new List<DoorRight> { new DoorRight() }));
            doorRightRepository.Setup(e => e.GetActiveRightsByTagsAndDoorID(tagIDList, 2)).Returns(Task.FromResult(new List<DoorRight> { }));

            var userTagRepository = new Mock<IUserTagRepository>();
            userTagRepository.Setup(e => e.GetActiveTagsByUserID(1)).Returns(Task.FromResult(tagList));
            userTagRepository.Setup(e => e.GetActiveTagsByUserID(2)).Returns(Task.FromResult(new List<UserTag>()));


            _doorRightService = new DoorRightService(doorRightRepository.Object, userTagRepository.Object);
        }

        [Fact]
        public void HasUserRightForDoor_UserHasNotAnyTag_False()
        {
            var result = _doorRightService.HasUserRightForDoor(2,1).Result;
            Assert.False(result);
        }

        [Fact]
        public void HasUserRightForDoor_UserHasTagHasNotRight_False()
        {
            var result = _doorRightService.HasUserRightForDoor(1, 2).Result;
            Assert.False(result);
        }

        [Fact]
        public void HasUserRightForDoor_UserHasTagHasRight_True()
        {
            var result = _doorRightService.HasUserRightForDoor(1, 1).Result;
            Assert.True(result);
        }
    }
}
