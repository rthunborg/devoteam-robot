using DevoRobot.Models;
using System;

namespace DevoRobot
{
    public static class InputParser
    {
        public static (int width, int depth) ParseRoomSize(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Room size input cannot be null or empty.");

            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                throw new FormatException("Room size must consist of two numbers separated by a space.");

            if (!int.TryParse(parts[0], out int width) || !int.TryParse(parts[1], out int depth))
                throw new FormatException("Room size must consist of two valid integers.");

            if (width <= 0 || depth <= 0)
                throw new ArgumentException("Room dimensions must be positive integers.");

            return (width, depth);
        }

        public static (int x, int y, Direction direction) ParseRobotPosition(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Robot position input cannot be null or empty.");

            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
                throw new FormatException("Robot position must consist of two numbers and a direction letter separated by spaces.");

            if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                throw new FormatException("Robot position coordinates must be valid integers.");

            if (!Enum.TryParse(parts[2], out Direction direction))
                throw new FormatException("Robot direction must be one of: N, E, S, W.");

            return (x, y, direction);
        }
    }
}
