using System.Numerics;
using MarsRover.Domain;

namespace MarsRover.Core.Orientation
{
    public class NOrientation : IOrientation
    {
        public Orientations GetOrientationType()
        {
            return Orientations.N;
        }

        public IOrientation Left()
        {
            return new WOrientation();
        }

        public IOrientation Right()
        {
            return new EOrientation();
        }

        public Vector2 GetDiffrenece()
        {
            return new Vector2(0,1);
        }
    }
}