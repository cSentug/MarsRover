using System;
using System.Numerics;

namespace MarsRover.Core.Plateau
{
    public class Plateau : IPlateau
    {
        private Vector2 _size { get; set; }

        public Plateau(int x, int y)
        {
            if(x < 0 || y < 0)
                throw new ArgumentOutOfRangeException();
            _size = new Vector2(x,y);
        }

        public Vector2 GetSize() => _size;
    }
}