using DevoRobot.Models;

namespace DevoRobot.Infrastructure.Interfaces
{
    public interface IRobotService
    {
        void SetRobot(Robot robot);
        void ProcessCommands(string? commands);
    }
}
