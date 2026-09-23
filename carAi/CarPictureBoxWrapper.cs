using System.Drawing;
using System.Windows.Forms;

namespace CarAI
{
    public class CarPictureBoxWrapper
    {
        public Car Car { get; private set; }
        public PictureBox PictureBox { get; private set; } = new PictureBox();
        public int Size => PictureBox.Image.Height;

        public CarPictureBoxWrapper(Track track, Car car)
        {
            Car = car;
            PictureBox.Location = new System.Drawing.Point(track.StartLocation.X, track.StartLocation.Y);
            Image image = Image.FromFile(GetRaceCarImagePath());
            image.RotateFlip(GetInitialRotation(track.StartingDirection));
            image = Viewer.ResizeImage(image, 10, 10);
            PictureBox.Image = image;
            PictureBox.Size = image.Size;
        }

        private string GetRaceCarImagePath()
        {
            string[] splits = Application.ExecutablePath.Split('\\');
            string path = "";

            foreach (string split in splits)
            {
                path += (path != "" ? "\\" : "") + split;

                if (split == "CarAi")
                    break;
            }

            path += "\\racecar.png";
            return path;
        }

        private RotateFlipType GetInitialRotation(Direction direction)
        {
            if (direction.Degrees == 270)
                return RotateFlipType.Rotate270FlipNone;

            return RotateFlipType.Rotate90FlipNone;
        }
    }
}
