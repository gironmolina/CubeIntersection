using System;
using CubeIntersection.Domain.Interfaces;
using CubeIntersection.Model;

namespace CubeIntersection.Domain.Services
{
    public class BorderService : IBorderService
    {
        public double Overlap(Border borderA, Border borderB)
        {
            return Math.Max(0, Difference(borderA, borderB));
        }

        public bool Collides(Border borderA, Border borderB)
        {
            return Difference(borderA, borderB) >= 0;
        }

        public double Difference(Border borderA, Border borderB)
        {
            return Math.Min(borderA.End, borderB.End) - Math.Max(borderA.Start, borderB.Start);
        }
    }
}
