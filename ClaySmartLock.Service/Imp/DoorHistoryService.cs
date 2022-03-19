using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Imp;
using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Service.DoorHistory;
using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    public class DoorHistoryService : IDoorHistoryService
    {
        private readonly DoorHistoryRepository _doorHistoryRepository;
        private readonly IMapper _mapper;

        public DoorHistoryService(DoorHistoryRepository doorHistoryRepository, IMapper mapper)
        {
            _doorHistoryRepository = doorHistoryRepository;
            _mapper = mapper;
        }

        public GetDoorHistoryServiceResponse GetDoorHistory(GetDoorHistoryServiceRequest request)
        {
            GetDoorHistoryServiceResponse response = new GetDoorHistoryServiceResponse();

            long doorID = request != null ? request.DoorID : 0;
            List<DoorHistory> doorHistory;

            if (doorID == 0)
            {
                doorHistory = _doorHistoryRepository.GetAll().Result;
            }
            else
            {
                doorHistory = _doorHistoryRepository.GetByDoorID(doorID).Result;
            }

            response.History = _mapper.Map<List<DoorHistoryDTO>>(doorHistory);

            return response;
        }

        public void InsertHistory(InsertDoorHistoryServiceRequest request)
        {
            DoorHistory doorHistory = new DoorHistory();
            doorHistory.ActionDate = DateTime.Now;
            doorHistory.ActionType = request.Action.GetHashCode();
            doorHistory.DoorID = request.DoorID;

            _doorHistoryRepository.Add(doorHistory);
        }
    }
}
