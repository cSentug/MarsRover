using System.Numerics;
using MarsRover.Domain;

namespace MarsRover.Core.Orientation
{
    public class SOrientation : IOrientation
    {
        public Orientations GetOrientationType()
        {
            return Orientations.S;
        }

        public IOrientation Left()
        {
            return new EOrientation();
        }

        public IOrientation Right()
        {
            return new WOrientation();
        }

        public Vector2 GetDiffrenece()
        {
            return new Vector2(0,-1);
        }
    }
}