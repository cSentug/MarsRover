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
    public class InstructionTest
    {
        public static IEnumerable<object[]> ExecuteForSideTurnsShouldUpdateOrientations
        {
            get
            {
                var rover = new Rover(1,2,new Plateau(5,5));
                rover.UpdateOrientation(new NOrientation());
                
                var rover2 = new Rover(1,2,new Plateau(5,5));
                rover2.UpdateOrientation(new NOrientation());

                return new[]
                {
                    new object[] { new TurnLeftInstruction(),rover ,Orientations.W },
                    new object[] { new TurnRightInstruction(),rover2 ,Orientations.E },
                };
               
            }
        }

        [Theory, MemberData(nameof(ExecuteForSideTurnsShouldUpdateOrientations))]
        public void Execute_For_SideTurns_Should_Update_Orientations(IInstruction instruction, IRover rover, Orientations expectedOrientation)
        {
            //arrange
            //act
            instruction.Execute(rover);
            var orientation = rover.GetOrientation();
            //assert
            Assert.Equal(expectedOrientation,orientation.GetOrientationType());
        }
        [Fact]
        public void Execute_For_MoveTowards_Should_Update_RoverPosition()
        {
            //arrange
            var rover = new Rover(1,2,new Plateau(5,5));
            rover.UpdateOrientation(new NOrientation());
            var instruction = new MoveTowardsInstruction();
            //act
            instruction.Execute(rover);
            //assert
            Assert.Equal(new Vector2(1,3), rover.GetPosition());
        }
    }
}