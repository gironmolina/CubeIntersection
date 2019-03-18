using CubeIntersection.Domain.Services;
using CubeIntersection.Model;
using Xunit;

namespace CubeIntersection.UnitTests.Domain
{
    public class CubeTests
    {
        [Fact]
        public void Cube_ThatDoNotCollides_ShouldReturnFalse()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(10, 10, 10), 2);

            // Act
            var result = cubeService.CollidesWith(cubeA, cubeB);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Cube_ThatOverlap_ShouldReturnTrue()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(3, 2, 2), 2);

            // Act
            var result = cubeService.CollidesWith(cubeA, cubeB);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Cube_ThatCollides_ShouldReturnTrue()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());

            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(4, 2, 2), 2);

            // Act
            var result = cubeService.CollidesWith(cubeA, cubeB);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Cube_ThatDoNotIntersect()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(10, 10, 10), 2);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Cube_WithSameHeightAndDepth()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(3, 2, 2), 2);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Cube_WithSameWithAndDepth()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 3, 2), 2);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Cube_WithSameWithAndHeight()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 2, 3), 2);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Cube_OneCubeIsContainedWithinTheOther()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 2, 2), 1);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Cube_AreCompletelyOverlapped()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 2, 2), 2);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Cube_AreTouchingButNotIntersecting()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(4, 2, 2), 2);

            // Act
            var result = cubeService.IntersectionVolumeWith(cubeA, cubeB);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Cube_IsCommutative()
        {
            // Arrange
            var cubeService = new CubeService(new BorderService());
            var cubeA = new Cube(new Position(0, 0, 0), 3);
            var cubeB = new Cube(new Position(2, 2, 2), 2);

            // Act
            var resultA = cubeService.IntersectionVolumeWith(cubeA, cubeB);
            var resultB = cubeService.IntersectionVolumeWith(cubeB, cubeA);

            // Assert
            Assert.Equal(resultA, resultB);
        }
    }
}
