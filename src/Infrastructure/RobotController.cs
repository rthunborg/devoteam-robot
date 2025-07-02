using System;

namespace DevoRobot
{
    public class RobotController(Robot robot)
    {
        private readonly Robot _robot = robot ?? throw new ArgumentNullException(nameof(robot));
    }
}
