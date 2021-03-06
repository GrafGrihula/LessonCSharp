using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class DotNetMetricsControllerTest
    {
        private readonly DotNetMetricsController controller;

        public DotNetMetricsControllerTest()
        {
            controller = new DotNetMetricsController();
        }


        [Fact]
        public void GetMetricsFromAgentReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds( 0 );
            var toTime = TimeSpan.FromSeconds( 100 );

            //Act
            var result = controller.GetMetricsFromAgent( agentId, fromTime, toTime );

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>( result );
        }


        [Fact]
        public void GetMetricsFromAllClusterReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetMetricsFromAllCluster(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
