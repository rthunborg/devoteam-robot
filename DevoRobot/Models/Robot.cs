using DevoRobot.Models;
using System;

namespace DevoRobot
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Facing { get; private set; }

        public Robot(int x, int y, Direction facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public void TurnLeft()
        {
            switch (Facing)
            {
                case Direction.N:
                    Facing = Direction.W;
                    break;
                case Direction.E:
                    Facing = Direction.N;
                    break;
                case Direction.S:
                    Facing = Direction.E;
                    break;
                case Direction.W:
                    Facing = Direction.S;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TurnRight()
        {
            switch (Facing)
            {
                case Direction.N:
                    Facing = Direction.E;
                    break;
                case Direction.E:
                    Facing = Direction.S;
                    break;
                case Direction.S:
                    Facing = Direction.W;
                    break;
                case Direction.W:
                    Facing = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void MoveForward()
        {
            switch (Facing)
            {
                case Direction.N:
                    Y += 1;
                    break;
                case Direction.E:
                    X += 1;
                    break;
                case Direction.S:
                    Y -= 1;
                    break;
                case Direction.W:
                    X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
