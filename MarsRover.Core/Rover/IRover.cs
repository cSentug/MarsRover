using System.Collections.Generic;
using System.Numerics;
using MarsRover.Core.Instruction;
using MarsRover.Core.Orientation;

namespace MarsRover.Core.Rover
{
    public interface IRover
    {
        void UpdateOrientation(IOrientation orientation);
        void UpdateInstructions(List<IInstruction> instructions);
        void MoveRover();
        IOrientation GetOrientation();
        Vector2 GetPosition();
        void UpdatePosition(Vector2 position);
        string ExposeData();
    }
}