using MetricsAgent.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route( "api/metrics/cpu" )]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _cpuMetricsRepository;


        public CpuMetricsController(
            ILogger<CpuMetricsController> logger,
            ICpuMetricsRepository cpuMetricsRepository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");

            _cpuMetricsRepository = cpuMetricsRepository;
        }



        [HttpGet( "agent/{agentId}/from/{fromTime}/to/{toTime}" )]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"agent {agentId} from {fromTime} to {toTime}");

            return Ok();
        }
    }
}
