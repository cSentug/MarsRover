using System.Numerics;
using MarsRover.Domain;

namespace MarsRover.Core.Orientation
{
    public class WOrientation : IOrientation
    {
        public Orientations GetOrientationType()
        {
            return Orientations.W;
        }
        

        public IOrientation Left()
        {
            return new SOrientation();
        }

        public IOrientation Right()
        {
            return new NOrientation();
        }

        public Vector2 GetDiffrenece()
        {
            return new Vector2(-1,0);
        }
    }
}