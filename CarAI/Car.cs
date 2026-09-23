using PanelDrawing_;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAI
{
    public class Car
    {
        public enum Stati { Good, Crashed }
        public Direction Direction { get; private set; } = new Direction();
        private Stati Status = Stati.Good;
        private const int MAXSPEED = 10;
        private const int MINSPEED = 1;
        private int Speed = 1;
        public Location StartLocation { get; private set; }
        public Location CurrentLocation { get; private set; }
        public List<CarLocation> DrivenWay { get; } = new List<CarLocation>();
        public int Id { get; private set; }
        private Random Random { get; set; } = new Random();
        private bool CanCrash = true;

        public Car(int id, Location startLocation, Direction direction, bool canCrash = true)
        {
            Id = id;
            CurrentLocation = StartLocation = startLocation;
            Direction = direction;
            CanCrash = canCrash;
        }


        // If driven enough moves
        private bool CheckSpeedUpPossible()
        {
            if (DrivenWay.Count == 0)
                return false;

            bool speedup = true;
            Direction lastDirection = DrivenWay.Last().Direction;

            for (int a = 0; a < 3; a++)
            {
                int index = DrivenWay.Count - 1 - a;
                if (index < 0)
                    break;

                if (DrivenWay[index].Direction.Degrees != lastDirection.Degrees)
                {
                    speedup = false;
                    break;
                }
            }

            return speedup && Speed + 1 <= MAXSPEED;
        }

        private Location GetNextRandomLocation(Track track, bool allowSpeedup = true)
        {
            if (allowSpeedup && CheckSpeedUpPossible())
                SpeedUp();

            int x = Direction.XDirection;
            int y = Direction.YDirection;

            Location tryLocation = new Location(CurrentLocation.X + x * Speed, CurrentLocation.Y + y * Speed);

            // scan circumstances
            // found valid location
            if (track.IsOnTrack(tryLocation))
                return tryLocation;

            if (CanCrash)
            {
                Status = Stati.Crashed;
                return CurrentLocation;
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

        public bool Move(Track track, Pilot? pilot)
        {
            DrivenWay.Add(new CarLocation(CurrentLocation, Direction));
            CurrentLocation = pilot == null ? GetNextRandomLocation(track) : GetNextTrainedLocation(track, pilot);
           
            return Status == Stati.Good;
        }

        private Location GetNextTrainedLocation(Track track, Pilot pilot)
        {
            return CurrentLocation;
        }
    }
}