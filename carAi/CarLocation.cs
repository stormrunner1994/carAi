using PanelDrawing_;

namespace CarAI
{
    public class CarLocation
    {
        public Location Location { get; private set; } = new Location(0, 0);
        public Direction Direction { get; private set; } = new Direction();

        public CarLocation(Location location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }
    }
}
