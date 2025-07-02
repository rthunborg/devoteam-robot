using DevoRobot.Models;

namespace DevoRobot.Infrastructure
{
    public class RobotService(Robot robot)
    {
        private readonly Robot _robot = robot ?? throw new ArgumentNullException(nameof(robot));

        public void ProcessCommands(string? commands)
        {
            if (string.IsNullOrEmpty(commands))
                return;

            foreach (char command in commands)
            {
                ProcessCommand(command);
            }
        }

        private void ProcessCommand(char command)
        {
            switch (command)
            {
                case 'L':
                    _robot.TurnLeft();
                    break;
                case 'R':
                    _robot.TurnRight();
                    break;
                case 'F':
                    _robot.MoveForward();
                    break;
                default:
                    throw new ArgumentException($"Unknown command: {command}");
            }
        }
    }
}

