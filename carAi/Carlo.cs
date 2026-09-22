namespace CarAI
{
    public class CarLocation
    {
        public Point Location { get; private set; } = new Point(0, 0);
        public Direction Direction { get; private set; } = new Direction();

        public CarLocation(Point location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }
    }
}
