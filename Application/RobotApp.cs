using DevoRobot.Infrastructure;
using DevoRobot.Models;
using DevoRobot.Application.Interfaces;
using DevoRobot.Utilities;
using DevoRobot.Infrastructure.Interfaces;

namespace DevoRobot.Application
{
    public class RobotApp(IRobotService robotService) : IRobotApp
    {
        private readonly IRobotService _robotService = robotService;
        public void Run()
        {
            try
            {
                Console.WriteLine("Enter a value for room size width and depth (x y):");
                var roomSizeInput = Console.ReadLine();
                (var width, var depth) = InputParser.ParseRoomSize(roomSizeInput);

                Console.WriteLine("Enter robot starting position and facing direction (x y N/E/S/W):");
                var positionInput = Console.ReadLine();
                var (x, y, direction) = InputParser.ParseRobotPosition(positionInput);

                var robot = new Robot(x, y, direction, width, depth);
                var _robotService = new RobotService(robot);

                Console.WriteLine("Enter navigation commands (L, R, F):");
                var commandsInput = Console.ReadLine();

                if (!InputParser.ValidateCommands(commandsInput))
                {
                    Console.WriteLine("Error: Commands must contain only L, R, or F characters.");
                    return;
                }

                _robotService.ProcessCommands(commandsInput);
                Console.WriteLine($"Report: {robot.ReportLocation()}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
