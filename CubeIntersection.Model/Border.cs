namespace CubeIntersection.Model
{
    public class Border
    {
        public double Start;
        public double End;

        public Border(double center, double length)
        {
            Start = center - length / 2.0;
            End = center + length / 2.0;
        }
    }
}
