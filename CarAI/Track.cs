using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PanelDrawing_;

namespace CarAI
{
    public class Track
    {
        public Direction StartingDirection { get; private set; } = new Direction();
        public Location StartLocation { get; private set; } = new Location(10, 10);
        public List<Location> BorderLocations  { get; set; } = new List<Location>();
        private List<Location> OuterBorderLocations { get; set; } = new List<Location>();
        private List<Location> InnerBorderLocations { get; set; } = new List<Location>();
        public Line StartFinishLine { get; private set; }
        public List<Line> OuterBorderLines { get; private set; } = new List<Line>();
        public List<Line> InnerBorderLines { get; private set; } = new List<Line>();

        public Track()
        {
            InnerBorderLocations.Add(new Location(40, 40));
            InnerBorderLocations.Add(new Location(100, 40));
            InnerBorderLocations.Add(new Location(100, 100));
            InnerBorderLocations.Add(new Location(40, 100));

            OuterBorderLocations.Add(new Location(10, 10));
            OuterBorderLocations.Add(new Location(130, 10));
            OuterBorderLocations.Add(new Location(130, 130));
            OuterBorderLocations.Add(new Location(10, 130));
            SimplifyTrackPath(4, 4);

            StartLocation = new Location(75, 115);
           // StartFinishLine = new Line(new Location())
        }

        public Track(Location startLocation, List<Location> innerBorderLocations, List<Location> outerBorderLocations)
        {
            StartLocation = startLocation;
            InnerBorderLocations = innerBorderLocations;
            OuterBorderLocations = outerBorderLocations;
        }


        public static Track LoadTrackFromFile(string file, int maxInnerBorderLines = 200, int maxOuterBorderLines = 200)
        {
            string error = "";

            try
            {
                List<string> list = new List<string>();
                Dictionary<int, int> dict = new Dictionary<int, int>();
                Track track = new Track();
                Bitmap bmp = new Bitmap(file);
                List<Location> borderLocations = new List<Location>();
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int argb = bmp.GetPixel(x, y).ToArgb();
                        if (argb == -16777216)
                            borderLocations.Add(new Location(x, y));


                        if (bmp.GetPixel(x, y).IsKnownColor)
                            list.Add(bmp.GetPixel(x, y).ToKnownColor().ToString());

                        if (dict.ContainsKey(argb))
                            dict[argb]++;
                        else
                            dict.Add(argb, 1);
                        //if (color == Color.Red)
                        //    track.StartFinishLine.Add(new Location(x, y));                        
                    }
                }

                track.BorderLocations = borderLocations;
                track.SetTrackPath(borderLocations);
                track.SimplifyTrackPath(maxInnerBorderLines, maxOuterBorderLines);
                return track;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return null;
        }

        private bool SimplifyTrackPath(int maxInnerBorderLines, int maxOuterBorderLines)
        {
            if (InnerBorderLocations.Count < 2 || OuterBorderLocations.Count < 2)
                return false;

            InnerBorderLines = new List<Line>();
            OuterBorderLines = new List<Line>();

            int stepsize = InnerBorderLocations.Count / maxInnerBorderLines;
            int index = stepsize;
            Location from = InnerBorderLocations.First();

            while (index < InnerBorderLocations.Count)
            {
                Location to = InnerBorderLocations[index];
                InnerBorderLines.Add(new Line(from, to, Line.Colors.Red, 2));
                from = to;
                index += stepsize;
            }
            // close the circle
            InnerBorderLines.Add(new Line(InnerBorderLines.Last().PointB, InnerBorderLines.First().PointA, Line.Colors.Red,2));


            stepsize = OuterBorderLocations.Count / maxOuterBorderLines;
            index = stepsize;
            from = OuterBorderLocations.First();

            while (index < OuterBorderLocations.Count)
            {
                Location to = OuterBorderLocations[index];
                OuterBorderLines.Add(new Line(from, to, Line.Colors.Blue, 2));
                from = to;
                index += stepsize;
            }
            // close the circle
            OuterBorderLines.Add(new Line(OuterBorderLines.Last().PointB, OuterBorderLines.First().PointA, Line.Colors.Blue, 2));

            return true;
        }

        private bool SetTrackPath(List<Location> borderLocations)
        {
            if (borderLocations.Count == 0) return false;

            OuterBorderLocations.Clear();
            InnerBorderLocations.Clear();

            List<Location> ordered = borderLocations; //.OrderBy(i => i.X).ToList();
            Location current = ordered.First();

            for (int a = 0; a < ordered.Count; a++)
            {
                current = ordered[a];
                Location closest = ordered.Last();
                double shortestDistance = Helper.CalcDistance(current, closest);

                // find Location with minmal distance
                for (int b = a + 1; b < ordered.Count; b++)
                {
                    double dist = Helper.CalcDistance(current, ordered[b]);
                    if (dist < shortestDistance)
                    {
                        closest = ordered[b];
                        shortestDistance = dist;
                    }

                    if (dist == 1)
                        break;
                }

                // circle finished
                if (shortestDistance > 50)
                    break;

                ordered.Remove(current);
                  a--;
                OuterBorderLocations.Add(closest);
            }

            // others should be inner border
            InnerBorderLocations.AddRange(ordered);

            return true;
        }

        public bool IsOnTrack(Location Location)
        {
            // first find lines where x in between
            var relevantInnerLines = InnerBorderLines.Where(i => i.PointA.X >= Location.X && i.PointB.X <= Location.X
             || i.PointA.X <= Location.X && i.PointB.X >= Location.X).ToList();

            var relevantOuterLines = OuterBorderLines.Where(i => i.PointA.X >= Location.X && i.PointB.X <= Location.X
          || i.PointA.X <= Location.X && i.PointB.X >= Location.X).ToList();

            if (!relevantInnerLines.Any() || !relevantOuterLines.Any())
                return false;


           // InnerBorderLines.FirstOrDefault(i=>i.Location1.X -Location.X)

            return true;
        }
    }
}