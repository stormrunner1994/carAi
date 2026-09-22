using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CarAI
{
    public static  class Viewer
    {
        private static Form1 Form;
        private static Track Track = new Track();
        private static List<CarPictureBoxWrapper> Cars = new List<CarPictureBoxWrapper>();
        public static void Init(Form1 form)
        {
            Form = form;
            Form.GetPanel().Paint += Viewer_Paint;
        }

        private static void Viewer_Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.Black;


            //Brush brush = new SolidBrush(color);
            //foreach (var point in Track.Borderpoints)
            //    e.Graphics.FillEllipse(brush, point.X, point.Y, 3, 3);

            // paint track borders
            foreach (var line in Track.OuterBorderLines)
                e.Graphics.DrawLine(new Pen(Color.Red), line.Point1.X, line.Point1.Y, line.Point2.X, line.Point2.Y);

            foreach (var line in Track.InnerBorderLines)
                e.Graphics.DrawLine(new Pen(Color.Blue), line.Point1.X, line.Point1.Y, line.Point2.X, line.Point2.Y);

            Form.GetPanel().Controls.Clear();
            foreach (CarPictureBoxWrapper wrapper in Cars)
                Form.GetPanel().Controls.Add(wrapper.PictureBox);
        }

        public static void DisplayTrack(Track track, List<CarPictureBoxWrapper> cars)
        {
            Track = track;
            Cars = cars;
            Form.GetPanel().Invalidate();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static void Rotate(PictureBox picturebox)
        {
            Image img = picturebox.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picturebox.Image = img;
        }


    }
}
