using MarsRover.Core.Rover;

namespace MarsRover.Core.Instruction
{
    public class MoveTowardsInstruction : IInstruction
    {
        public void Execute(IRover rover)
        {
            var targetPosition = rover.GetOrientation().GetDiffrenece() + rover.GetPosition();
            rover.UpdatePosition(targetPosition);
        }
    }
}