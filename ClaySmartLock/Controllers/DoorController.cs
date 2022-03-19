using ClaySmartLock.Model.Contract;
using ClaySmartLock.Model.Service.Door;
using ClaySmartLock.Service.Interface;
using Microsoft.AspNetCore.Http;
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


        public DoorController(IDoorService doorService, IUserService userService, IDoorRightService doorRightService)
        {
            _doorService = doorService;
            _userService = userService;
            _doorRightService = doorRightService;
        }


        [HttpPost("unlock")]
        public async Task<ActionResult<DoorUnLockResponse>> UnLock([FromBody] DoorUnLockRequest request)
        {
            bool hasRight = await _doorRightService.HasUserRightForDoor(_userService.GetAuthenticatedUser().ID, request.DoorID);
            if (!hasRight)
                return StatusCode(StatusCodes.Status403Forbidden);

            DoorUnlockServiceRequest doorUnlockServiceRequest = new DoorUnlockServiceRequest 
            { 
                DoorID = request.DoorID
            };

            DoorUnlockServiceResponse doorUnlockServiceResponse = await _doorService.UnLockDoor(doorUnlockServiceRequest);

            DoorUnLockResponse response = new DoorUnLockResponse
            {
                Message = doorUnlockServiceResponse.Message
            };

            return Ok(response);
        }

        [HttpPost("lock")]
        public async Task<ActionResult<DoorLockResponse>> Lock([FromBody] DoorUnLockRequest request)
        {
            bool hasRight = await _doorRightService.HasUserRightForDoor(_userService.GetAuthenticatedUser().ID, request.DoorID);
            if (!hasRight)
                return StatusCode(StatusCodes.Status403Forbidden);

            DoorLockServiceRequest doorLockServiceRequest = new DoorLockServiceRequest
            {
                DoorID = request.DoorID
            };

            DoorLockServiceResponse doorLockServiceResponse = await _doorService.LockDoor(doorLockServiceRequest);

            DoorLockResponse response = new DoorLockResponse
            {
                Message = doorLockServiceResponse.Message
            };

            return Ok(response);
        }
    }
}
