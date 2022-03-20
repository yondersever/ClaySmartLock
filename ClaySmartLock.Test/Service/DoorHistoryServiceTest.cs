

using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Service.Imp;
using ClaySmartLock.Service.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using ClaySmartLock.Model.Service.DoorHistory;
using ClaySmartLock.Service.Mapper;

namespace ClaySmartLock.Test.Service
{
    public class DoorHistoryServiceTest
    {
        private readonly IDoorHistoryService _doorHistoryService;

        public DoorHistoryServiceTest()
        {
            var doorHistoryRepository = new Mock<IDoorHistoryRepository>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()).CreateMapper();

            var doorHistoryList = new List<DoorHistory>()
            {
                new DoorHistory{ ActionDate = DateTime.Now, ActionType = 1, DoorID = 1, ID = 1, UserID = 1},
                new DoorHistory{ ActionDate = DateTime.Now, ActionType = 1, DoorID = 1, ID = 2, UserID = 2},
                new DoorHistory{ ActionDate = DateTime.Now, ActionType = 1, DoorID = 2, ID = 3, UserID = 1},
            };

            doorHistoryRepository.Setup(e => e.GetAllByChilds()).Returns(Task.FromResult(doorHistoryList));
            doorHistoryRepository.Setup(e => e.GetByDoorID(1)).Returns(Task.FromResult(doorHistoryList.Where(i => i.DoorID == 1).ToList()));
            doorHistoryRepository.Setup(e => e.GetByDoorID(3)).Returns(Task.FromResult(new List<DoorHistory>()));
            doorHistoryRepository.Setup(e => e.Add(It.IsAny<DoorHistory>())).Returns(Task.FromResult(new DoorHistory()));

            _doorHistoryService = new DoorHistoryService(doorHistoryRepository.Object, mapper);
        }

        [Fact]
        public void GetAllDoorHistory_NotEmptyList()
        {
            var result = _doorHistoryService.GetDoorHistory(null).Result;
            Assert.NotEmpty(result.History);
        }

        [Fact]
        public void GetDoorHistoryByID_NotEmptyList()
        {
            var result = _doorHistoryService.GetDoorHistory(new GetDoorHistoryServiceRequest { DoorID = 1 }).Result;
            Assert.NotEmpty(result.History);
        }

        [Fact]
        public void GetDoorHistoryByID_EmptyList()
        {
            var result = _doorHistoryService.GetDoorHistory(new GetDoorHistoryServiceRequest { DoorID = 3 }).Result;
            Assert.Empty(result.History);
        }

        [Fact]
        public void InsertHistory_NotNullResponse()
        {
            var result = _doorHistoryService.InsertHistory(new InsertDoorHistoryServiceRequest());
            Assert.NotNull(result);
        }
    }
}
