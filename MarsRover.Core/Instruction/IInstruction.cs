using MarsRover.Core.Rover;

namespace MarsRover.Core.Instruction
{
    public interface IInstruction
    {
        void Execute(IRover rover);
    }
}