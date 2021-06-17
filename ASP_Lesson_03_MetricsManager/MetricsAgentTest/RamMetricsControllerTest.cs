using MetricsAgent;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MetricsAgentTest
{
    public class RamMetricsControllerTest
    {
        private readonly RamMetricsController _controller;
        private readonly Mock<ILogger<RamMetricsController>> _mockLog;
        private readonly Mock<IRamMetricsRepository> _mockRep;

        public RamMetricsControllerTest()
        {
            _mockLog = new Mock<ILogger<RamMetricsController>>();
            _mockRep = new Mock<IRamMetricsRepository>();
            _controller = new RamMetricsController(_mockLog.Object, _mockRep.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mockRep.Setup(r => r.GetByTimePeriod(startTime, stopTime)).Returns(new List<RamMetric>());

            var result = _controller.GetMetricsFromAgent(startTime, stopTime);

           _mockRep.Verify(repository => repository.GetByTimePeriod(startTime, stopTime), Times.Once());
        }
    }
}