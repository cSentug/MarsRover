using System.Numerics;
using MarsRover.Domain;

namespace MarsRover.Core.Orientation
{
    public class EOrientation: IOrientation
    {
        public Orientations GetOrientationType()
        {
            return Orientations.E;
        }

        public IOrientation Left()
        {
            return new NOrientation();
        }

        public IOrientation Right()
        {
            return new SOrientation();
        }
        public Vector2 GetDiffrenece()
        {
            return new Vector2(1,0);
        }
    }
}