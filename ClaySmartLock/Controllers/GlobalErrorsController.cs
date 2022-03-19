using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaySmartLock.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GlobalErrorsController : ControllerBase
    {
        private readonly ILogger _logger;

        public GlobalErrorsController(ILogger<GlobalErrorsController> logger)
        {
            _logger = logger;
        }

        [Route("/errors")]
        public IActionResult HandleErrors()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError(exception.Error.Message);

            return Problem("Something went wrong.");
        }
    }
}
