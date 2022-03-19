using ClaySmartLock.Model.Contract.DoorHistory;
using ClaySmartLock.Model.Service.DoorHistory;
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
    public class DoorHistoryController : ControllerBase
    {

        private IDoorHistoryService _doorHistoryService;

        public DoorHistoryController(IDoorHistoryService doorHistoryService)
        {
            _doorHistoryService = doorHistoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetDoorHistoryServiceRequest serviceRequest = new GetDoorHistoryServiceRequest();
            GetDoorHistoryServiceResponse serviceResponse = _doorHistoryService.GetDoorHistory(serviceRequest);

            GetDoorHistoryResponse response = new GetDoorHistoryResponse
            {
                History = serviceResponse.History
            };

            return Ok(response);
        }

        [HttpGet("{doorID}")]
        public IActionResult Get(long doorID)
        {
            GetDoorHistoryServiceRequest serviceRequest = new GetDoorHistoryServiceRequest()
            {
                DoorID = doorID
            };

            GetDoorHistoryServiceResponse serviceResponse = _doorHistoryService.GetDoorHistory(serviceRequest);

            GetDoorHistoryResponse response = new GetDoorHistoryResponse
            {
                History = serviceResponse.History
            };

            return Ok(response);
        }
    }
}
