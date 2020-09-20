using MarsRover.Core.Rover;

namespace MarsRover.Core.Instruction
{
    public class TurnRightInstruction : IInstruction
    {
        public void Execute(IRover rover)
        {
            rover.UpdateOrientation(rover.GetOrientation().Right());
        }
    }
}