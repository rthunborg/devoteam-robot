using DevoRobot.Infrastructure.Interfaces;
using DevoRobot.Models;


namespace DevoRobot.Infrastructure
{
    public class RobotService : IRobotService
    {
        private Robot? _robot;

        public void SetRobot(Robot robot)
        {
            _robot = robot;
        }

        public void ProcessCommands(string? commands)
        {
            if (string.IsNullOrEmpty(commands))
                throw new InvalidOperationException("No commands given.");

            foreach (char command in commands)
            {
                ProcessCommand(command);
            }
        }

        private void ProcessCommand(char command)
        {
            if (_robot is null)
                throw new InvalidOperationException("Robot not set. Call SetRobot() before using this service.");

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

