using CubeIntersection.Model;

namespace CubeIntersection.Domain.Interfaces
{
    public interface ICubeService
    {
        double IntersectionVolumeWith(Cube cubeA, Cube cubeB);
        bool CollidesWith(Cube cubeA, Cube cubeB);
    }
}
