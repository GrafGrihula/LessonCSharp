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
    public class NetworkMetricsControllerTest
    {
        private readonly NetworkMetricsController _controller;
        private readonly Mock<ILogger<NetworkMetricsController>> _mockLog;
        private readonly Mock<INetworkMetricsRepository> _mockRep;

        public NetworkMetricsControllerTest()
        {
            _mockLog = new Mock<ILogger<NetworkMetricsController>>();
            _mockRep = new Mock<INetworkMetricsRepository>();
            _controller = new NetworkMetricsController(_mockLog.Object, _mockRep.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mockRep.Setup(r => r.GetByTimePeriod(startTime, stopTime)).Returns(new List<NetworkMetric>());

            var result = _controller.GetMetricsFromAgent(startTime, stopTime);

           _mockRep.Verify(repository => repository.GetByTimePeriod(startTime, stopTime), Times.Once());
        }
    }
}