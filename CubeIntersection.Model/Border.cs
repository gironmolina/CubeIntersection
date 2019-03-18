using System;

namespace CubeIntersection.Model
{
    public class Border
    {
        private readonly double _start;
        private readonly double _end;

        public Border(double center, double length)
        {
            _start = center - length / 2.0;
            _end = center + length / 2.0;
        }

        public double Overlap(Border border)
        {
            return Math.Max(0, Difference(border));
        }

        public bool Collides(Border border)
        {
            return Difference(border) >= 0;
        }

        private double Difference(Border border)
        {
            return Math.Min(_end, border._end) - Math.Max(_start, border._start);
        }
    }
}
