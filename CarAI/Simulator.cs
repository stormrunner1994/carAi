using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarAI
{
    public class CarPictureBoxWrapper
    {
        public Car Car { get; private set; }
        public PictureBox PictureBox { get; private set; }
        public int Size => PictureBox.Image.Height;
            
        public CarPictureBoxWrapper(Track track, Car car)
        {
            Car = car;
            PictureBox = new PictureBox();
            PictureBox.Location = new System.Drawing.Point(track.StartPoint.X, track.StartPoint.Y);
            Image image = Image.FromFile("racecar.png");
            image.RotateFlip(GetInitialRotation(track.StartingDirection));
            image = Viewer.ResizeImage(image, 10, 10);
            PictureBox.Image = image;
            PictureBox.Size = image.Size;
        }

        private RotateFlipType GetInitialRotation(Car.Directions direction)
        {
            if (direction == Car.Directions.Left)
                return RotateFlipType.Rotate270FlipNone;

            return RotateFlipType.Rotate90FlipNone;
        }
    }

    public class Simulator
    {
        public enum Stati { Running, NotRunning, WaitToStop, None }
        public enum TerminationReasons { Time, Steps, None }
        public bool Aborted = false;
        public int MaxRunningSecs = 20;
        public int MaxRunningSteps = 20;
        public int CurrentSteps = 0;
        private Stopwatch Stopwatch = new Stopwatch();
        public Track Track = new Track();
        public TerminationReasons TerminationReason;
        public Stati Status = Stati.NotRunning;
        public List<CarPictureBoxWrapper> Cars = new List<CarPictureBoxWrapper>();

        public Simulator(int numberCars = 5)
        {
            Init(numberCars, true);
        }

        private void Init(int numberCars, bool canCrash)
        {
            Track track = new Track();
            Cars = new List<CarPictureBoxWrapper>();

            for (int a = 0; a < numberCars; a++)
            {
                Car car = new Car(Cars.Count, track.StartPoint, track.StartingDirection, canCrash);
                CarPictureBoxWrapper wrapper = new CarPictureBoxWrapper(track, car);
                Cars.Add(wrapper);
            }


            //   Track.LoadTrackFromFile("track.png", 80,80);
            Viewer.DisplayTrack(track, Cars);
        }

        public bool Start(TerminationReasons stopreason, int value)
        {
            if (stopreason == TerminationReasons.Steps)
                MaxRunningSteps = value;
            else if (stopreason == TerminationReasons.Time)
                MaxRunningSecs = value;
            else
                return false;

            Aborted = false;
            TerminationReason = stopreason;
            Status = Stati.Running;
            Task.Run(() => TaskRun());
            return true;
        }

        public bool CheckContinueRunning()
        {
            return (TerminationReason == TerminationReasons.Steps && CurrentSteps <= MaxRunningSteps
                 || TerminationReason == TerminationReasons.Time && Stopwatch.ElapsedMilliseconds <= MaxRunningSecs * 1000)
                 && Status != Stati.WaitToStop;
        }


        public Task TaskRun()
        {
            Stopwatch.Restart();
            CurrentSteps = 0;

            while (CheckContinueRunning())
            {
                for (int c = 0; c < Cars.Count; c++)
                {
                    if (!CheckContinueRunning())
                        break;

                    CarPictureBoxWrapper wrapper = Cars[c];

                    // Car crashed?
                    if (!wrapper.Car.Move(Track, null))
                        Cars.RemoveAt(c);
                    else
                    {
                        // rotate if needed
                    }


                    Point current = wrapper.Car.CurrentLocation;
                    Invoker_.Invoker.invokeSetLocation(wrapper.PictureBox, new System.Drawing.Point(current.X, current.Y));
                    // Thread.Sleep(1);
                }
                CurrentSteps++;
            }

            Status = Stati.NotRunning;
            return Task.CompletedTask;
        }

        public void Stop()
        {
            Aborted = true;
            Status = Stati.WaitToStop;
        }

    }
}