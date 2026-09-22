using System;

namespace CarAI
{
    // goes clockwise 0° is top, 180° is showing down
    public class Direction
    {
        private int MaxDirectionValues => 16;
        public enum DiscretDirections { Left, Top, Right, Bottom }
        public int Degrees { get; private set; } = 270;
        // for now only allow x and y values in range -16 until 16
        public int XDirection { get; private set; } = 0;
        // for now only allow x and y values in range -16 until 16
        public int YDirection { get; private set; } = 0;

        public Direction()
        {
            UpdateByDegrees(270);
        }

        public Direction(int degrees)
        {
            Degrees = degrees;
            UpdateByDegrees(Degrees);
        }

        public Direction(DiscretDirections discretDirection)
        {
            switch (discretDirection)
            {
                case DiscretDirections.Left: Degrees = 270; break;
                case DiscretDirections.Top: Degrees = 0; break;
                case DiscretDirections.Bottom: Degrees = 180; break;
                case DiscretDirections.Right: Degrees = 90; break;
            }

            UpdateByDegrees(Degrees);
        }

        public void UpdateByDegrees(int degrees)
        {
            if (degrees < 0)
                return;

            while (degrees > 360)
                degrees -= 360;

            Degrees = degrees;
            double asin = Math.Asin(degrees);

            if (degrees == 0 || degrees == 360)
            {
                YDirection = MaxDirectionValues;
                XDirection = 0;
            }
            else if (degrees < 90)
            {
            }
            else if (degrees == 90)
            {
                YDirection = 0;
                XDirection = MaxDirectionValues;
            }
            else if (degrees < 180)
            {
            }
            else if (degrees == 180)
            {
                YDirection = -MaxDirectionValues;
                XDirection = 0;
            }
            else if (degrees < 270)
            {
            }
            else if (degrees == 270)
            {
                YDirection = 0;
                XDirection = -MaxDirectionValues;
            }
            else if (degrees < 360)
            {
            }
        }
    }
}