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
    public class CpuMetricsControllerTest
    {
        private readonly CpuMetricsController _controller;
        private readonly Mock<ILogger<CpuMetricsController>> _mockLog;
        private readonly Mock<ICpuMetricsRepository> _mockRep;

        public CpuMetricsControllerTest()
        {
            _mockLog = new Mock<ILogger<CpuMetricsController>>();
            _mockRep = new Mock<ICpuMetricsRepository>();
            _controller = new CpuMetricsController(_mockLog.Object, _mockRep.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mockRep.Setup(r => r.GetByTimePeriod(startTime, stopTime)).Returns(new List<CpuMetric>());

            var result = _controller.GetMetricsFromAgent(startTime, stopTime);

           _mockRep.Verify(repository => repository.GetByTimePeriod(startTime, stopTime), Times.Once());
        }
    }
}