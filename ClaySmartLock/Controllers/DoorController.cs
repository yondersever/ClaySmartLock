using ClaySmartLock.Model.Contract;
using ClaySmartLock.Model.Service.Door;
using ClaySmartLock.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClaySmartLock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {

        private IDoorService _doorService;
        private IUserService _userService;
        private IDoorRightService _doorRightService;

        private const string _forbiddenMessage = "You don't have enought rights for this door";
        private const string _successMessage = "Operation successfully completed";

        public DoorController(IDoorService doorService, IUserService userService, IDoorRightService doorRightService)
        {
            _doorService = doorService;
            _userService = userService;
            _doorRightService = doorRightService;
        }


        [HttpPost("unlock")]
        public IActionResult UnLock([FromBody] DoorUnLockRequest request)
        {
            if (!_doorRightService.HasUserRightForDoor(_userService.GetAuthenticatedUser().ID, request.DoorID))
                return Forbid(_forbiddenMessage);

            DoorUnlockServiceRequest doorUnlockServiceRequest = new DoorUnlockServiceRequest 
            { 
                DoorID = request.DoorID 
            };

            DoorUnlockServiceResponse doorUnlockServiceResponse = _doorService.UnLockDoor(doorUnlockServiceRequest);

            DoorUnLockResponse response = new DoorUnLockResponse
            {
                Message = _successMessage
            };

            return Ok(response);
        }

        [HttpPost("lock")]
        public IActionResult Lock([FromBody] DoorUnLockRequest request)
        {
            if (!_doorRightService.HasUserRightForDoor(_userService.GetAuthenticatedUser().ID, request.DoorID))
                return Forbid(_forbiddenMessage);

            DoorLockServiceRequest doorLockServiceRequest = new DoorLockServiceRequest
            {
                DoorID = request.DoorID
            };

            DoorLockServiceResponse doorLockServiceResponse = _doorService.LockDoor(doorLockServiceRequest);

            DoorLockResponse response = new DoorLockResponse
            {
                Message = doorLockServiceResponse.Message
            };

            return Ok(response);
        }
    }
}
