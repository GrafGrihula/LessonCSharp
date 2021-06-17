using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerTest
    {
        private readonly AgentsController controller;

        public AgentsControllerTest()
        {
            AgentsHolder holder = new AgentsHolder();
            controller = new AgentsController(holder);
        }


        [Fact]
        public void RegisterAgentReturnsOk()
        {
            //Arrange
            var agentInfo = new AgentInfo(1, new Uri("http://adress"));

            //Act
            var result = controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>( result );
        }


        [Fact]
        public void EnableAgentByIdReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = controller.EnableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void DisableAgentByIdReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = controller.DisableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetAgentsListReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetAgentsList();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
