using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerTest
    {
        private readonly CpuMetricsController controller;

        public CpuMetricsControllerTest()
        {
            controller = new CpuMetricsController();
        }


        [Fact]
        public void GetMetricsToManagerReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetMetricsToManager(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
