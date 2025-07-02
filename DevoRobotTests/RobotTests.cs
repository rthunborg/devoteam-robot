using DevoRobot.Models;
using Xunit;

namespace DevoRobotTests
{
    public class RobotTests
    {
        [Fact]
        public void InitializeWithValidPosition_ShouldSucceed()
        {
            // Arrange & Act
            var robot = new Robot(1, 2, Direction.N, 5, 5);

            // Assert
            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
            Assert.Equal(Direction.N, robot.Facing);
        }

        [Theory]
        [InlineData(6, 5, Direction.N, 5, 5)]
        [InlineData(-1, 0, Direction.N, 5, 5)]
        public void Initialize_WithInvalidPosition_ShouldThrowException(int x, int y, Direction facing, int width, int depth)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Robot(x, y, facing, width, depth));
        }

        [Fact]
        public void TurnLeft_ShouldChangeDirectionCorrectly()
        {
            // Arrange
            var robot = new Robot(1, 2, Direction.N, 5, 5);

            // Act & Assert
            robot.TurnLeft();
            Assert.Equal(Direction.W, robot.Facing);

            robot.TurnLeft();
            Assert.Equal(Direction.S, robot.Facing);

            robot.TurnLeft();
            Assert.Equal(Direction.E, robot.Facing);

            robot.TurnLeft();
            Assert.Equal(Direction.N, robot.Facing);
        }

        [Fact]
        public void TurnRight_ShouldChangeDirectionCorrectly()
        {
            // Arrange
            var robot = new Robot(1, 2, Direction.N, 5, 5);

            // Act & Assert
            robot.TurnRight();
            Assert.Equal(Direction.E, robot.Facing);

            robot.TurnRight();
            Assert.Equal(Direction.S, robot.Facing);

            robot.TurnRight();
            Assert.Equal(Direction.W, robot.Facing);

            robot.TurnRight();
            Assert.Equal(Direction.N, robot.Facing);
        }

        [Theory]
        [InlineData(Direction.N, 2, 1)]
        [InlineData(Direction.E, 3, 2)]
        [InlineData(Direction.S, 2, 3)]
        [InlineData(Direction.W, 1, 2)]
        public void MoveForward_ShouldChangePositionBasedOnDirection(Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var robot = new Robot(2, 2, direction, 5, 5);

            // Act
            robot.MoveForward();

            // Assert
            Assert.Equal(expectedX, robot.X);
            Assert.Equal(expectedY, robot.Y);
        }

        [Fact]
        public void MoveOutsideRoomBoundaries_ShouldThrowException()
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N, 5, 5);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => robot.MoveForward());
        }

        [Fact]
        public void MoveInAllDirections_ShouldReturnToStartPosition()
        {
            // Arrange
            var robot = new Robot(2, 2, Direction.N, 5, 5);

            // Act (move in a square)
            robot.MoveForward();  // North: (2, 1)
            robot.TurnRight();    // Face East
            robot.MoveForward();  // East: (3, 1)
            robot.TurnRight();    // Face South
            robot.MoveForward();  // South: (3, 2)
            robot.TurnRight();    // Face West
            robot.MoveForward();  // West: (2, 2)

            // Assert
            Assert.Equal(2, robot.X);
            Assert.Equal(2, robot.Y);
        }

        [Fact]
        public void ReportLocation_ShouldReturnCorrectFormat()
        {
            // Arrange
            var robot = new Robot(1, 2, Direction.N, 5, 5);

            // Act
            string result = robot.ReportLocation();

            // Assert
            Assert.Equal("1 2 N", result);
        }
    }
}
