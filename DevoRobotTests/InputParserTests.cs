using DevoRobot.Utilities;
using Xunit;

namespace DevoRobotTests
{
    public class InputParserTests
    {
        [Theory]
        [InlineData("5 7", 5, 7)]
        [InlineData("1000 2000", 1000, 2000)]
        public void ParseRoomSize_ValidInput_ShouldReturnCorrectValues(string input, int expectedWidth, int expectedDepth)
        {
            // Act
            var (width, depth) = InputParser.ParseRoomSize(input);

            // Assert
            Assert.Equal(expectedWidth, width);
            Assert.Equal(expectedDepth, depth);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-5 7")]
        [InlineData("0 0")]
        public void ParseRoomSize_InvalidInput_ShouldThrowArgumentException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseRoomSize(input));
        }

        [Theory]
        [InlineData("5")]
        [InlineData("five seven")]
        public void ParseRoomSize_InvalidFormat_ShouldThrowFormatException(string input)
        {
            // Act & Assert
            Assert.Throws<FormatException>(() => InputParser.ParseRoomSize(input));
        }

        [Theory]
        [InlineData("3 3 N", 3, 3, Direction.N)]
        public void ParseRobotPosition_ValidInput_ShouldReturnCorrectValues(string input, int expectedX, int expectedY, Direction expectedDirection)
        {
            // Act
            var (x, y, direction) = InputParser.ParseRobotPosition(input);

            // Assert
            Assert.Equal(expectedX, x);
            Assert.Equal(expectedY, y);
            Assert.Equal(expectedDirection, direction);
        }

        [Fact]
        public void ParseRobotPosition_EmptyInput_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseRobotPosition(""));
        }

        [Theory]
        [InlineData("3 3")]
        public void ParseRobotPosition_InvalidFormat_ShouldThrowFormatException(string input)
        {
            // Act & Assert
            Assert.Throws<FormatException>(() => InputParser.ParseRobotPosition(input));
        }

        [Theory]
        [InlineData("3 3 X")]
        public void ParseRobotPosition_InvalidDirection_ShouldThrowFormatException(string input)
        {
            // Act & Assert
            Assert.Throws<FormatException>(() => InputParser.ParseRobotPosition(input));
        }

        [Theory]
        [InlineData("LRFRL", true)]
        [InlineData("LRFRXL", false)]
        [InlineData("", false)]
        public void ValidateCommands_ShouldReturnCorrectResult(string commands, bool expected)
        {
            // Act
            bool result = InputParser.ValidateCommands(commands);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1 1 N", Direction.N)]
        [InlineData("1 1 E", Direction.E)]
        [InlineData("1 1 S", Direction.S)]
        [InlineData("1 1 W", Direction.W)]
        public void ParseRobotPosition_AllDirections_ShouldReturnCorrectEnum(string input, Direction expectedDirection)
        {
            // Act
            var (_, _, direction) = InputParser.ParseRobotPosition(input);

            // Assert
            Assert.Equal(expectedDirection, direction);
        }
    }
}
