using System;

namespace DevoRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter room size (width depth):");
                var roomSizeInput = Console.ReadLine();
                var (width, depth) = InputParser.ParseRoomSize(roomSizeInput);

                Console.WriteLine("Enter robot starting position and choose facing direction N/E/S/W (x y direction):");
                var positionInput = Console.ReadLine();
                var (x, y, direction) = InputParser.ParseRobotPosition(positionInput);

                var robot = new Robot(x, y, direction, width, depth);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
