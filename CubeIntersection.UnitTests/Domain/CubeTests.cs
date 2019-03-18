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
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(10, 10, 10), 2);

            // Act
            var result = cubeA.CollidesWith(cubeB);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Cube_ThatOverlap_ShouldReturnTrue()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(3, 2, 2), 2);

            // Act
            var result = cubeA.CollidesWith(cubeB);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Cube_ThatCollides_ShouldReturnTrue()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(4, 2, 2), 2);

            // Act
            var result = cubeA.CollidesWith(cubeB);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Cube_ThatDoNotInterset()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(10, 10, 10), 2);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Cube_WithSameHeightAndDepth()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(3, 2, 2), 2);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Cube_WihtSameWithAndDepth()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 3, 2), 2);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Cube_WihtSameWithAndHeight()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 2, 3), 2);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Cube_OneCubeIsContainedWithinTheOther()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 2, 2), 1);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Cube_AreCompletelyOverlapped()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(2, 2, 2), 2);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Cube_AreTouchingButNotIntersecting()
        {
            // Arrange
            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(4, 2, 2), 2);

            // Act
            var result = cubeA.IntersectionVolumeWith(cubeB);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Cube_IsCommutative()
        {
            // Arrange
            var cubeA = new Cube(new Position(0, 0, 0), 3);
            var cubeB = new Cube(new Position(2, 2, 2), 2);

            // Act
            var resultA = cubeA.IntersectionVolumeWith(cubeB);
            var resultB = cubeB.IntersectionVolumeWith(cubeA);

            // Assert
            Assert.Equal(resultA, resultB);
        }
    }
}
