using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Imp;
using ClaySmartLock.DataAccess.Repository.Interface;
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
        private readonly IDoorHistoryRepository _doorHistoryRepository;
        private readonly IMapper _mapper;

        public DoorHistoryService(IDoorHistoryRepository doorHistoryRepository, IMapper mapper)
        {
            _doorHistoryRepository = doorHistoryRepository;
            _mapper = mapper;
        }

        public async Task<GetDoorHistoryServiceResponse> GetDoorHistory(GetDoorHistoryServiceRequest request)
        {
            GetDoorHistoryServiceResponse response = new GetDoorHistoryServiceResponse();

            long doorID = request != null ? request.DoorID : 0;
            List<DoorHistory> doorHistory;

            if (doorID == 0)
            {
                doorHistory = await _doorHistoryRepository.GetAllByChilds();
            }
            else
            {
                doorHistory = await _doorHistoryRepository.GetByDoorID(doorID);
            }

            response.History = _mapper.Map<List<DoorHistoryDTO>>(doorHistory);

            return response;
        }

        public async Task<DoorHistoryDTO> InsertHistory(InsertDoorHistoryServiceRequest request)
        {
            DoorHistory doorHistory = new DoorHistory()
            {
                ActionDate = DateTime.Now,
                ActionType = request.Action.GetHashCode(),
                DoorID = request.DoorID,
                UserID = request.UserID
            };

            doorHistory = await _doorHistoryRepository.Add(doorHistory);

            return _mapper.Map<DoorHistoryDTO>(doorHistory);
        }
    }
}
