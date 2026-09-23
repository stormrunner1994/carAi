using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PanelDrawing_
{
    public static class PanelDrawing
    {
        private static Panel Panel { get; set; }
        private static List<Line> Lines { get; set; } = new List<Line>();
        private static List<TextField> TextFields { get; set; } = new List<TextField>();
        private static List<Ellipse> Ellipses { get; set; } = new List<Ellipse>();
        private static List<Button> Buttons { get; set; } = new List<Button>();
        private static List<Point> Points { get; set; } = new List<Point>();

        public static void Init(Panel panel)
        {
            Panel = panel;
            Panel.Paint += Panel_Paint;
            Panel.Invalidate();
        }

        private static void Panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (Line line in Lines)
                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromName(line.Color.ToString())), line.Width), line.PointA.X,
                    line.PointA.Y, line.PointB.X, line.PointB.Y);

            Font font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            foreach (var textfield in TextFields)
                e.Graphics.DrawString(textfield.Text, font, new SolidBrush(Color.Black), textfield.Point.X, textfield.Point.Y);

            foreach (Ellipse ellipse in Ellipses)
                e.Graphics.DrawEllipse(new Pen(Color.FromName(ellipse.Color.ToString())),
                    ellipse.Location.X, ellipse.Location.Y, ellipse.Width, ellipse.Height);

            foreach (Button button in Buttons)
            {
                System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                but.Height = button.Height;
                but.Text = button.Text;
                but.Width = button.Width;
                but.Location = new System.Drawing.Point(button.Location.X, button.Location.Y);
                Panel.Controls.Add(but);
            }

            foreach (Point point in Points)
                e.Graphics.DrawEllipse(new Pen(Color.FromName(point.Color.ToString())),
                    point.Location.X, point.Location.Y, point.Size, point.Size);
        }

        public static void Update(List<TextField> textFields,
          List<Line> lines, List<Ellipse> ellipses, List<Button> buttons)
        {
            Lines = lines;
            TextFields = textFields;
            Ellipses = ellipses;
            Buttons = buttons;
            Panel.Invalidate();
        }

        public static void Update(List<Element> elements)
        {
            Lines = elements.Where(i => i is Line).Select(i => i as Line).ToList();
            TextFields = elements.Where(i => i is TextField).Select(i => i as TextField).ToList();
            Ellipses = elements.Where(i => i is Ellipse).Select(i => i as Ellipse).ToList();
            Buttons = elements.Where(i => i is Button).Select(i => i as Button).ToList();
            Points = elements.Where(i => i is Point).Select(i => i as Point).ToList();
            Panel.Invalidate();
        }
    }

    public class Element
    {

    }

    public class Button : Element
    {
        public enum Colors { Red, Orange, Blue, LightBlue }
        public Location Location { get; set; }
        public string Text { get; set; }
        public Colors BackColor { get; set; }
        public bool Enabled { get; set; } = false;
        public int Height { get; set; } = 30;
        public int Width { get; set; } = 30;

        public Button(string text, Colors color)
        {
            Width = text.Length < 3 ? text.Length * 12 + 15 : text.Length * 10 + 15;
            BackColor = color;
            Text = text;
        }
    }

    public class TextField : Element
    {
        public Location Point { get; set; }
        public string Text { get; set; }
        public TextField(Location point, string text)
        {
            Point = point;
            Text = text;
        }
    }

    public class Line : Element
    {
        public enum Colors { Black, Red, Blue }
        public Colors Color { get; set; }
        public Location PointA { get; set; }
        public Location PointB { get; set; }
        public int Width { get; set; }
        public Line(Location pointA, Location pointB, Colors color, int width)
        {
            PointA = pointA;
            PointB = pointB;
            Color = color;
            Width = width;
        }

        public override string ToString()
        {
            return PointA.ToString() + PointB.ToString();
        }
    }

    public class Ellipse : Element
    {
        public enum Colors { Black, Red }
        public Location Location { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Colors Color { get; set; }
        public Ellipse(Location location, int height, int width, Colors color)
        {
            Location = location;
            Height = height;
            Width = width;
            Color = color;
        }
    }

    public class Point : Element
    {
        public enum Colors { Black, Red, White, Green }
        public Colors Color { get; private set; } = Colors.Black;
        public Location Location { get; private set; }
        public int Size { get; private set; }

        public Point(Location location, int size)
        {
            Location = location;
            Size = size;
        }

        public Point(Location location, int size, Colors color)
        {
            Color = color;
            Location = location;
            Size = size;
        }
    }

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return (X + "/" + Y);
        }
    }
}