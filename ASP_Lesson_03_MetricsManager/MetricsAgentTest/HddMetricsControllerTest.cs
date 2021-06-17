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
    public class HddMetricsControllerTest
    {
        private readonly HddMetricsController _controller;
        private readonly Mock<ILogger<HddMetricsController>> _mockLog;
        private readonly Mock<IHddMetricsRepository> _mockRep;

        public HddMetricsControllerTest()
        {
            _mockLog = new Mock<ILogger<HddMetricsController>>();
            _mockRep = new Mock<IHddMetricsRepository>();
            _controller = new HddMetricsController(_mockLog.Object, _mockRep.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mockRep.Setup(r => r.GetByTimePeriod(startTime, stopTime)).Returns(new List<HddMetric>());

            var result = _controller.GetMetricsFromAgent(startTime, stopTime);

           _mockRep.Verify(repository => repository.GetByTimePeriod(startTime, stopTime), Times.Once());
        }
    }
}