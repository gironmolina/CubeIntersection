namespace CubeIntersection.Model
{
    public class Cube
    {
        public Border Width;
        public Border Height;
        public Border Depth;

        public Cube(Position center, double length)
        {
            Width = new Border(center.X, length);
            Height = new Border(center.Y, length);
            Depth = new Border(center.Z, length);
        }
    }
}
