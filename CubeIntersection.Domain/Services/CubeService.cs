using CubeIntersection.Domain.Interfaces;
using CubeIntersection.Model;

namespace CubeIntersection.Domain.Services
{
    public class CubeService : ICubeService
    {
        private readonly IBorderService _borderService;

        public CubeService(IBorderService borderService)
        {
            _borderService = borderService;
        }

        public double IntersectionVolumeWith(Cube cubeA, Cube cubeB)
        {
            return _borderService.Overlap(cubeA.Width, cubeB.Width) *
                   _borderService.Overlap(cubeA.Height, cubeB.Height) *
                   _borderService.Overlap(cubeA.Depth, cubeB.Depth);
        }

        public bool CollidesWith(Cube cubeA, Cube cubeB)
        {
            return _borderService.Collides(cubeA.Width, cubeB.Width) ||
                   _borderService.Collides(cubeA.Height, cubeB.Height) ||
                   _borderService.Collides(cubeA.Depth, cubeB.Depth);
        }
    }
}
