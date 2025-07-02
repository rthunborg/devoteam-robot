using DevoRobot.Infrastructure;
using DevoRobot.Models;
using DevoRobot.Utilities;
using Xunit;

namespace DevoRobotTests
{
    public class IntegrationTests
    {
        [Theory]
        [InlineData("5 5", "1 2 N", "RFRFFRFRF", "1 3 N")]
        [InlineData("5 5", "0 0 E", "RFLFFLRF", "3 1 E")]
        public void ProcessCommands_Examples_ShouldProduceCorrectResults(string roomSize, string robotPosition, string commands, string expectedResult)
        {
            // Arrange
            var (service, robot) = CreateServiceWithRobot(roomSize, robotPosition);

            // Act
            service.ProcessCommands(commands);
            string result = robot.ReportLocation();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void MoveOutsideBoundaries_ShouldThrowException()
        {
            // Arrange
            var (service, _) = CreateServiceWithRobot("3 3", "0 0 W");
            const string commands = "F";

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => service.ProcessCommands(commands));
        }

        [Fact]
        public void ComplexPatternMovement_WithBoundaryViolation_ShouldThrowException()
        {
            // Arrange
            var (service, _) = CreateServiceWithRobot("5 5", "2 2 N");
            const string commands = "FFRFFLFRFF";

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => service.ProcessCommands(commands));
        }

        [Theory]
        [InlineData("5 5", "2 2 N", "LLRRRLLR", "2 2 N")]
        public void OnlyTurnsNoMovement_ShouldKeepSamePosition(string roomSize, string robotPosition, string commands, string expectedResult)
        {
            // Arrange
            var (service, robot) = CreateServiceWithRobot(roomSize, robotPosition);

            // Act
            service.ProcessCommands(commands);
            var result = robot.ReportLocation();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("5 5", "2 2 N", "FFRFFL", "4 0 N")]
        public void ComplexPatternMovement_SafePart_ShouldEndAtCorrectPosition(string roomSize, string robotPosition, string commands, string expectedResult)
        {
            // Arrange
            var (service, robot) = CreateServiceWithRobot(roomSize, robotPosition);

            // Act
            service.ProcessCommands(commands);
            var result = robot.ReportLocation();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        private (RobotService service, Robot robot) CreateServiceWithRobot(string roomSize, string position)
        {
            var (width, depth) = InputParser.ParseRoomSize(roomSize);
            var (x, y, direction) = InputParser.ParseRobotPosition(position);

            var robot = new Robot(x, y, direction, width, depth);
            var service = new RobotService();
            service.SetRobot(robot);

            return (service, robot);
        }
    }
}
