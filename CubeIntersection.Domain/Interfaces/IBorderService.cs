using CubeIntersection.Model;

namespace CubeIntersection.Domain.Interfaces
{
    public interface IBorderService
    {
        double Overlap(Border borderA, Border borderB);
        bool Collides(Border borderA, Border borderB);
        double Difference(Border borderA, Border borderB);
    }
}
