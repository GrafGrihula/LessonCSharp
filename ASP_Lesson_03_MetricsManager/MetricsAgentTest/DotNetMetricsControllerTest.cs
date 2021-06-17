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
    public class DotNetMetricsControllerTest
    {
        private readonly DotNetMetricsController _controller;
        private readonly Mock<ILogger<DotNetMetricsController>> _mockLog;
        private readonly Mock<IDotNetMetricsRepository> _mockRep;

        public DotNetMetricsControllerTest()
        {
            _mockLog = new Mock<ILogger<DotNetMetricsController>>();
            _mockRep = new Mock<IDotNetMetricsRepository>();
            _controller = new DotNetMetricsController(_mockLog.Object, _mockRep.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mockRep.Setup(r => r.GetByTimePeriod(startTime, stopTime)).Returns(new List<DotNetMetric>());

            var result = _controller.GetMetricsFromAgent(startTime, stopTime);

           _mockRep.Verify(repository => repository.GetByTimePeriod(startTime, stopTime), Times.Once());
        }
    }
}