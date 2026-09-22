using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAI
{
    public class CarLocation
    {
        private Point Location;
        private Car.Directions Direction;

        public CarLocation(Point location, Car.Directions direction)
        {
            Location = location;
            Direction = direction;
        }

        public Car.Directions GetDirection()
        {
            return Direction;
        }
    }

    public class Car
    {
        public enum Stati { Good, Crashed }
        public enum Directions { Left, Right, Up, Down }
        private Directions Direction = Directions.Up;
        private Stati Status = Stati.Good;
        private const int MAXSPEED = 10;
        private const int MINSPEED = 1;
        private int Speed = 1;
        public Point StartLocation { get; private set; }
        public Point CurrentLocation { get; private set; }
        public List<CarLocation> DrivenWay { get; } = new List<CarLocation>();
        public int Id { get; private set; }
        private Random Random { get; set; } = new Random();
        private bool CanCrash = true;

        public Car(int id, Point startingPoint, Directions direction = Directions.Left, bool canCrash = true)
        {
            Id = id;
            CurrentLocation = StartLocation = startingPoint;
            Direction = direction;
            CanCrash = canCrash;
        }


        // If driven enough moves
        private bool CheckSpeedUpPossible()
        {
            if (DrivenWay.Count == 0)
                return false;

            bool speedup = true;
            Directions lastDirection = DrivenWay.Last().GetDirection();

            for (int a = 0; a < 3; a++)
            {
                int index = DrivenWay.Count - 1 - a;
                if (index < 0)
                    break;

                if (DrivenWay[index].GetDirection() != lastDirection)
                {
                    speedup = false;
                    break;
                }
            }

            return speedup && Speed + 1 <= MAXSPEED;
        }

        private Point GetNextRandomLocation(Track track, bool allowSpeedup = true)
        {
            if (allowSpeedup && CheckSpeedUpPossible())
                SpeedUp();


            // Training()

            int x = 0;
            if (Direction == Directions.Left)
                x = -1;
            else if (Direction == Directions.Right)
                x = 1;

            int y = 0;
            if (Direction == Directions.Up)
                y = -1;
            else if (Direction == Directions.Down)
                y = 1;

            Point tryPoint = new Point(CurrentLocation.X + x * Speed, CurrentLocation.Y + y * Speed);

            // scan circumstances
            // found valid location
            if (track.IsOnTrack(tryPoint))
                return tryPoint;

            if (CanCrash)
            {
                Status = Stati.Crashed;
                return CurrentLocation;
            }

            // try out
            for (int a = 0; a < 100; a++)
            {
                x = Random.Next(-1, 2);
                y = Random.Next(-1, 2);
                tryPoint = new Point(CurrentLocation.X + x * Speed, CurrentLocation.Y + y * Speed);
                if (track.IsOnTrack(tryPoint))
                {
                    if (x == -1)
                        Direction = Directions.Left;
                    else if (x == 1)
                        Direction = Directions.Right;

                    if (y == -1)
                        Direction = Directions.Up;
                    else if (y == 1)
                        Direction = Directions.Down;

                    return tryPoint;
                }
            }
            if (CanCrash)
                Status = Stati.Crashed;

            return CurrentLocation;
        }

        private void SpeedUp()
        {
            Speed++;
        }

        private void SpeedDown()
        {
            if (Speed - 1 >= MINSPEED)
                Speed--;
        }

        public bool Move(Track track, Training training)
        {
            DrivenWay.Add(new CarLocation(CurrentLocation, Direction));
            CurrentLocation = training == null ? GetNextRandomLocation(track) : GetNextTrainedLocation(track, training);
           
            return Status == Stati.Good;
        }

        private Point GetNextTrainedLocation(Track track, Training training)
        {
            return CurrentLocation;

        }

        public Directions GetDirection()
        {
            return Direction;
        }

        public void Rotate90Degrees()
        {
            if (Direction == Directions.Left) Direction = Directions.Up;
            if (Direction == Directions.Down) Direction = Directions.Left;
            if (Direction == Directions.Right) Direction = Directions.Down;
            if (Direction == Directions.Up) Direction = Directions.Right;
        }
    }
}