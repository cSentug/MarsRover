using System;
using System.Numerics;
using MarsRover.Core.Plateau;
using Xunit;

namespace MarsRover.Test
{
    public class PlateauTest
    {
        private IPlateau _plateau;
        
        [Fact]
        public void Constructor_Should_Throw_Exception_When_ParameterNegative()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Plateau(-5, 2));
        }
        
        [Fact]
        public void Constructor_Should_Successfully_Initialized()
        {
            //arrange
            _plateau = new Plateau(5, 5);
            //act
            //assert
            Assert.NotNull(_plateau);
        }
        
        [Fact]
        public void GetSize_Should_Return_PlateauSize()
        {
            //arrange
            _plateau = new Plateau(5, 5);
            //act
            var size = _plateau.GetSize();
            //assert
            Assert.Equal(new Vector2(5,5), size);
        }
        
    }
}