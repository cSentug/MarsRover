using System;
using System.Collections.Generic;
using System.Numerics;
using MarsRover.Core.Instruction;
using MarsRover.Core.Orientation;
using MarsRover.Core.Plateau;
using MarsRover.Core.Rover;
using MarsRover.Domain;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        private IPlateau _plateau;
        public static IEnumerable<object[]> ConstructorShouldThrowExceptionWhenPositionNegativeCollection
        {
            get
            {
                return new[]
                {
                    new object[] { -1,2 },
                    new object[] { 1,-2 },
                    new object[] { -1,-2 },
                };
               
            }
        }

        public RoverTest()
        {
            _plateau = new Plateau(5,5);
        }

        [Fact]
        public void Constructor_Should_Throw_Exception_When_ParametersNull()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => new Rover(1,2,null));
        }
        [Theory, MemberData(nameof(ConstructorShouldThrowExceptionWhenPositionNegativeCollection))]
        public void Constructor_Should_Throw_Exception_When_PositionNegative(int x, int y)
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rover(x,y,_plateau));
        }
        [Fact]
        public void UpdateOrientation_Should_Throw_Exception_When_Parameter_IsNull()
        {
            //arrange
            var rover = new Rover(1, 2, _plateau);
            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => rover.UpdateOrientation(null));
        }
        [Fact]
        public void UpdateInstructions_Should_Throw_Exception_When_Parameter_IsNull()
        {
            //arrange
            var rover = new Rover(1, 2, _plateau);
            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => rover.UpdateInstructions(null));
        }
        [Fact]
        public void MoveRover_Should_Throw_Exception_When_Dont_Have_Instruction()
        {
            //arrange
            var rover = new Rover(1, 2, _plateau);
            //act
            //assert
            Assert.Throws<IndexOutOfRangeException>(() => rover.MoveRover());
        }
        [Fact]
        public void MoveRover_Should_Move_To_Given_Position()
        {
            //arrangeLMLMLMLMM
            var rover = new Rover(1, 2, _plateau);
            rover.UpdateOrientation(new NOrientation());
            rover.UpdateInstructions(new List<IInstruction>()
            {
                new TurnLeftInstruction(),
                new MoveTowardsInstruction(),
                new TurnLeftInstruction(),
                new MoveTowardsInstruction(),
                new TurnLeftInstruction(),
                new MoveTowardsInstruction(),
                new TurnLeftInstruction(),
                new MoveTowardsInstruction(),
                new MoveTowardsInstruction()
            });
            //act
            rover.MoveRover();
            //assert
            Assert.Equal("1 3 N",rover.ExposeData());
        }
        [Fact]
        public void GetOrientation_Should_Throw_Exception_When_Dont_Have_Orientation()
        {
            //arrange
            var rover = new Rover(1, 2, _plateau);
            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => rover.GetOrientation());
        }
        [Fact]
        public void GetPosition_Should_Return_Rovers_Position()
        {
            //arrange
            var rover = new Rover(1, 2, _plateau);
            //act
            //assert
            Assert.Equal(new Vector2(1,2),rover.GetPosition());
        }
        [Fact]
        public void UpdatePosition_Should_Update_Rovers_Position()
        {
            //arrange
            var rover = new Rover(1, 2, _plateau);
            rover.UpdatePosition(new Vector2(2, 3));
            //act
            //assert
            Assert.Equal(new Vector2(2,3),rover.GetPosition());
        }
    }
}