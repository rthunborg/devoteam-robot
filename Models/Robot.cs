namespace DevoRobot.Models
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Facing { get; private set; }
        private readonly int _roomWidth;
        private readonly int _roomDepth;

        public Robot(int x, int y, Direction facing, int roomWidth, int roomDepth)
        {
            X = x;
            Y = y;
            Facing = facing;
            _roomWidth = roomWidth;
            _roomDepth = roomDepth;

            ValidatePosition();
        }

        public void TurnLeft()
        {
            Facing = Facing switch
            {
                Direction.N => Direction.W,
                Direction.E => Direction.N,
                Direction.S => Direction.E,
                Direction.W => Direction.S,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public void TurnRight()
        {
            Facing = Facing switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
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

            ValidatePosition();
        }

        public string ReportLocation()
        {
            return $"{X} {Y} {Facing}";
        }

        private void ValidatePosition()
        {
            if (X < 0 || X > _roomWidth || Y < 0 || Y > _roomDepth)
            {
                throw new ArgumentOutOfRangeException($"Robot is outside of room boundaries. Position: ({X}, {Y})");
            }
        }
    }
}
