using CubeIntersection.Domain.Interfaces;
using CubeIntersection.Model;

namespace CubeIntersection.Domain.Services
{
    public class Cube : ICube
    {
        private readonly Border _width;
        private readonly Border _height;
        private readonly Border _depth;

        public Cube(Position center, double length)
        {
            _width = new Border(center.X, length);
            _height = new Border(center.Y, length);
            _depth = new Border(center.Z, length);
        }

        public double IntersectionVolumeWith(Cube cube)
        {
            return _width.Overlap(cube._width) * 
                   _height.Overlap(cube._height) * 
                   _depth.Overlap(cube._depth);
        }

        public bool CollidesWith(Cube cube)
        {
            return _width.Collides(cube._width) || 
                   _height.Collides(cube._height) ||
                   _depth.Collides(cube._depth);
        }
    }
}
