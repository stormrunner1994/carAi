using PanelDrawing_;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace CarAI
{
    public static  class Viewer
    {
        private static Form1 Form;
        private static List<CarPictureBoxWrapper> Cars = new List<CarPictureBoxWrapper>();
        public static void Init(Form1 form)
        {
            Form = form;
            PanelDrawing.Init(Form.GetPanel());
        }    

        public static void DisplayTrack(Track track, List<CarPictureBoxWrapper> cars)
        {
            Cars = cars;

            List<Element> elements = new List<Element>();
            elements.AddRange(track.OuterBorderLines);
            elements.AddRange(track.InnerBorderLines);
            PanelDrawing.Update(elements);

            Form.GetPanel().Controls.Clear();
            foreach (CarPictureBoxWrapper wrapper in Cars)
                Form.GetPanel().Controls.Add(wrapper.PictureBox);
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
