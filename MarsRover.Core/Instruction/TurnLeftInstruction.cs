using MarsRover.Core.Rover;

namespace MarsRover.Core.Instruction
{
    public class TurnLeftInstruction : IInstruction
    {
        public void Execute(IRover rover)
        {
            rover.UpdateOrientation(rover.GetOrientation().Left());
        }
    }
}