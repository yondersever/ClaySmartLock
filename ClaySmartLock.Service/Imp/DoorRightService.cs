using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.DataAccess.Repository.Imp;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Imp
{
    public class DoorRightService : IDoorRightService
    {
        private readonly IDoorRightRepository _doorRightRepository;
        private readonly IUserTagRepository _userTagRepository;

        public DoorRightService(IDoorRightRepository doorRightRepository, IUserTagRepository userTagRepository)
        {
            _doorRightRepository = doorRightRepository;
            _userTagRepository = userTagRepository;
        }

        public bool HasUserRightForDoor(long userID, long doorID)
        {
            List<UserTag> userTags = _userTagRepository.GetActiveTagsByUserID(userID).Result;

            if (userTags.Count == 0)
                return false;


            List<DoorRight> doorRights = _doorRightRepository.GetActiveRightsByTagsAndDoorID(userTags.Select(e => e.ID).ToList(), doorID).Result;
            return doorRights.Count > 0;
        }
    }
}
