using DevoRobot.Infrastructure;
using DevoRobot.Models;
using DevoRobot.Application.Interfaces;
using DevoRobot.Utilities;

namespace DevoRobot.Application
{
    public class RobotApp : IRobotApp
    {
        public void Run()
        {
            try
            {
                Console.WriteLine("Enter room size (width depth):");
                var roomSizeInput = Console.ReadLine();
                (var width, var depth) = InputParser.ParseRoomSize(roomSizeInput);

                Console.WriteLine("Enter robot starting position and facing direction (x y N/E/S/W):");
                var positionInput = Console.ReadLine();
                var (x, y, direction) = InputParser.ParseRobotPosition(positionInput);

                var robot = new Robot(x, y, direction, width, depth);
                var robotService = new RobotService(robot);

                Console.WriteLine("Enter navigation commands (L, R, F):");
                var commandsInput = Console.ReadLine();

                if (!InputParser.ValidateCommands(commandsInput))
                {
                    Console.WriteLine("Error: Commands must contain only L, R, or F characters.");
                    return;
                }

                robotService.ProcessCommands(commandsInput);
                Console.WriteLine($"Report: {robot.ReportLocation()}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
