using System;

namespace Omgtu
{
    public class Coordinates
    {
        public int X;
        public int Y;

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string GetPosition()
        {
            return $"({X}, {Y})";
        }
    }

    public class BoundaryEvent
    {
        public Coordinates OffBoundsPoint;

        public BoundaryEvent(Coordinates point)
        {
            OffBoundsPoint = point;
            Console.WriteLine("Событие: точка вышла за границы");
        }
    }

    public delegate void BoundaryHandler(Coordinates point);

    public class Arena
    {
        public Coordinates topLeftCorner;
        public Coordinates topRightCorner;
        public Coordinates bottomLeftCorner;
        public Coordinates bottomRightCorner;
        public int minX, maxX;
        public int minY, maxY;

        public Coordinates currentPosition;

        public event BoundaryHandler OnBoundaryCross;

        public Arena(Coordinates topLeft, Coordinates topRight, Coordinates bottomLeft, Coordinates bottomRight, Coordinates startPos)
        {
            topLeftCorner = topLeft;
            topRightCorner = topRight;
            bottomLeftCorner = bottomLeft;
            bottomRightCorner = bottomRight;
            currentPosition = startPos;

            minX = Math.Min(topLeft.X, Math.Min(topRight.X, Math.Min(bottomLeft.X, bottomRight.X)));
            maxX = Math.Max(topLeft.X, Math.Max(topRight.X, Math.Max(bottomLeft.X, bottomRight.X)));
            minY = Math.Min(topLeft.Y, Math.Min(topRight.Y, Math.Min(bottomLeft.Y, bottomRight.Y)));
            maxY = Math.Max(topLeft.Y, Math.Max(topRight.Y, Math.Max(bottomLeft.Y, bottomRight.Y)));
        }

        private Random rand = new Random();

        public bool IsWithinBoundary()
        {
            return (currentPosition.X >= minX && currentPosition.X <= maxX
                    && currentPosition.Y >= minY && currentPosition.Y <= maxY);
        }

        public void MakeRandomStep()
        {
            int deltaX = rand.Next(-2, 3);
            int deltaY = rand.Next(-2, 3);

            currentPosition.X += deltaX;
            currentPosition.Y += deltaY;

            if (!IsWithinBoundary())
            {
                OnBoundaryCross?.Invoke(currentPosition);
            }

            Console.WriteLine($"Текущая позиция: {currentPosition.GetPosition()}");
        }
    }

    class Program
    {
        static void Main()
        {
            var TopLeft = new Coordinates(-5, 7);
            var TopRight = new Coordinates(15, 7);
            var BottomLeft = new Coordinates(-5, -3);
            var BottomRight = new Coordinates(15, -3);

            var startPoint = new Coordinates(4, 2);

            var arena = new Arena(topLeft: TopLeft, topRight: TopRight, bottomLeft: BottomLeft, bottomRight: BottomRight, startPos: startPoint);
            arena.OnBoundaryCross += (pos) =>
            {
                Console.WriteLine($"Точка {pos.GetPosition()} вышла за пределы");
            };

            for (int i = 0; i < 15; i++)
            {
                arena.MakeRandomStep();
            }
        }
    }
}
