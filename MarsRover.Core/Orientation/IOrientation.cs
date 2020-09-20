using System.Numerics;
using MarsRover.Domain;

namespace MarsRover.Core.Orientation
{
    public interface IOrientation
    {
        Orientations GetOrientationType();
        IOrientation Left();
        IOrientation Right();
        Vector2 GetDiffrenece();
    }
}