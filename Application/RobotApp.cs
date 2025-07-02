using DevoRobot.Infrastructure.Interfaces;
using DevoRobot.Models;
using DevoRobot.Application.Interfaces;
using DevoRobot.Utilities;

namespace DevoRobot.Application
{
    public class RobotApp(IRobotService robotService) : IRobotApp
    {
        private readonly IRobotService _robotService = robotService;

        public void Run()
        {
            try
            {
                Console.WriteLine("Enter a value between 1-9 for room size width and depth (x y):");
                var roomSizeInput = Console.ReadLine();
                var (width, depth) = InputParser.ParseRoomSize(roomSizeInput);

                Console.WriteLine("Enter robot starting position and facing direction (x y N/E/S/W):");
                var positionInput = Console.ReadLine();
                var (x, y, direction) = InputParser.ParseRobotPosition(positionInput);

                var robot = new Robot(x, y, direction, width, depth);
                _robotService.SetRobot(robot);

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
