using ClaySmartLock.Model.Contract.DoorIOTClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaySmartLock.Controllers
{
    // Mock controller to simulate iot services
    [Route("api/[controller]")]
    [ApiController]
    public class DoorIOTMockController : ControllerBase
    {
        [HttpPost("unlock")]
        public ActionResult<DoorIOTClientUnLockResponse> UnLock([FromBody] DoorIOTClientUnLockRequest request)
        {
            DoorIOTClientUnLockResponse response = new DoorIOTClientUnLockResponse();
            response.Message = "OK";
            throw new NullReferenceException("opss");
            return Ok(response);
        }

        [HttpPost("lock")]
        public ActionResult<DoorIOTClientLockResponse> UnLock([FromBody] DoorIOTClientLockRequest request)
        {
            DoorIOTClientLockResponse response = new DoorIOTClientLockResponse();
            response.Message = "OK";
            return Ok(response);
        }
    }
}
