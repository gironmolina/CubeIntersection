using CubeIntersection.Domain.Services;

namespace CubeIntersection.Domain.Interfaces
{
    public interface ICube
    {
        double IntersectionVolumeWith(Cube cube);
        bool CollidesWith(Cube cube);
    }
}
