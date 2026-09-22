using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CarAI
{
    public class Track
    {
        public Direction StartingDirection { get; private set; } = new Direction();
        public Point StartPoint { get; private set; } = new Point(10, 10);
        public List<Point> Borderpoints  { get; set; } = new List<Point>();
        private List<Point> OuterBorderPoints { get; set; } = new List<Point>();
        private List<Point> InnerBorderPoints { get; set; } = new List<Point>();
        public Line StartFinishLine { get; private set; }
        public List<Line> OuterBorderLines { get; private set; } = new List<Line>();
        public List<Line> InnerBorderLines { get; private set; } = new List<Line>();

        public Track()
        {
            InnerBorderPoints.Add(new Point(40, 40));
            InnerBorderPoints.Add(new Point(100, 40));
            InnerBorderPoints.Add(new Point(100, 100));
            InnerBorderPoints.Add(new Point(40, 100));

            OuterBorderPoints.Add(new Point(10, 10));
            OuterBorderPoints.Add(new Point(130, 10));
            OuterBorderPoints.Add(new Point(130, 130));
            OuterBorderPoints.Add(new Point(10, 130));
            SimplifyTrackPath(4, 4);

            StartPoint = new Point(75, 115);
           // StartFinishLine = new Line(new Point())
        }

        public Track(Point startPoint, List<Point> innerBorderPoints, List<Point> outerBorderPoints)
        {
            StartPoint = startPoint;
            InnerBorderPoints = innerBorderPoints;
            OuterBorderPoints = outerBorderPoints;
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
                List<Point> borderPoints = new List<Point>();
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int argb = bmp.GetPixel(x, y).ToArgb();
                        if (argb == -16777216)
                            borderPoints.Add(new Point(x, y));


                        if (bmp.GetPixel(x, y).IsKnownColor)
                            list.Add(bmp.GetPixel(x, y).ToKnownColor().ToString());

                        if (dict.ContainsKey(argb))
                            dict[argb]++;
                        else
                            dict.Add(argb, 1);
                        //if (color == Color.Red)
                        //    track.StartFinishLine.Add(new Point(x, y));                        
                    }
                }

                track.Borderpoints = borderPoints;
                track.SetTrackPath(borderPoints);
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
            if (InnerBorderPoints.Count < 2 || OuterBorderPoints.Count < 2)
                return false;

            InnerBorderLines = new List<Line>();
            OuterBorderLines = new List<Line>();

            int stepsize = InnerBorderPoints.Count / maxInnerBorderLines;
            int index = stepsize;
            Point from = InnerBorderPoints.First();

            while (index < InnerBorderPoints.Count)
            {
                Point to = InnerBorderPoints[index];
                InnerBorderLines.Add(new Line(from, to));
                from = to;
                index += stepsize;
            }
            // close the circle
            InnerBorderLines.Add(new Line(InnerBorderLines.Last().Point2, InnerBorderLines.First().Point1));


            stepsize = OuterBorderPoints.Count / maxOuterBorderLines;
            index = stepsize;
            from = OuterBorderPoints.First();

            while (index < OuterBorderPoints.Count)
            {
                Point to = OuterBorderPoints[index];
                OuterBorderLines.Add(new Line(from, to));
                from = to;
                index += stepsize;
            }
            // close the circle
            OuterBorderLines.Add(new Line(OuterBorderLines.Last().Point2, OuterBorderLines.First().Point1));

            return true;
        }

        private bool SetTrackPath(List<Point> borderPoints)
        {
            if (borderPoints.Count == 0) return false;

            OuterBorderPoints.Clear();
            InnerBorderPoints.Clear();

            List<Point> ordered = borderPoints; //.OrderBy(i => i.X).ToList();
            Point current = ordered.First();

            for (int a = 0; a < ordered.Count; a++)
            {
                current = ordered[a];
                Point closest = ordered.Last();
                double shortestDistance = Helper.CalcDistance(current, closest);

                // find point with minmal distance
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
                OuterBorderPoints.Add(closest);
            }

            // others should be inner border
            InnerBorderPoints.AddRange(ordered);

            return true;
        }

        public bool IsOnTrack(Point point)
        {
            // first find lines where x in between
            var relevantInnerLines = InnerBorderLines.Where(i => i.Point1.X >= point.X && i.Point2.X <= point.X
             || i.Point1.X <= point.X && i.Point2.X >= point.X).ToList();

            var relevantOuterLines = OuterBorderLines.Where(i => i.Point1.X >= point.X && i.Point2.X <= point.X
          || i.Point1.X <= point.X && i.Point2.X >= point.X).ToList();

            if (!relevantInnerLines.Any() || !relevantOuterLines.Any())
                return false;


           // InnerBorderLines.FirstOrDefault(i=>i.Point1.X -point.X)

            return true;
        }
    }
}