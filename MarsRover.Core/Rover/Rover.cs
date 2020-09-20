using System;
using System.Collections.Generic;
using System.Numerics;
using MarsRover.Core.Instruction;
using MarsRover.Core.Orientation;
using MarsRover.Core.Plateau;

namespace MarsRover.Core.Rover
{
    public class Rover : IRover
    {
        private IPlateau _plateau;
        private Vector2 _position;
        private IOrientation _orientation;
        private List<IInstruction> _instructions = new List<IInstruction>();
        
        
        public Rover(int x, int y, IPlateau plateau)
        {
            _plateau = plateau ?? throw new ArgumentNullException();
            if(DoesCoordinatesInPlateau(new Vector2(x,y)))
                throw new ArgumentOutOfRangeException();
            _position = new Vector2(x,y);
        }

        public void UpdateOrientation(IOrientation orientation)
        {
            _orientation = orientation ?? throw new ArgumentNullException();
        }

        public IOrientation GetOrientation() => _orientation ?? throw new ArgumentNullException();
        public Vector2 GetPosition() => _position;

        public void UpdatePosition(Vector2 position)
        {
            _position = position;
        }
        
        public void UpdateInstructions(List<IInstruction> instructions)
        {
            _instructions = instructions ?? throw new ArgumentNullException();
        }
        public void MoveRover()
        {
            if(_instructions.Count <= 0)
                throw new IndexOutOfRangeException();
            foreach (var instruction in _instructions)
            {
                instruction.Execute(this);
            }
            Console.WriteLine(ExposeData());
        }
        
        //private methods
        private bool DoesCoordinatesInPlateau(Vector2 coordinates)
        {
            var maxPosition = _plateau.GetSize();
            return (coordinates.X < 0 || coordinates.Y < 0
                                      || coordinates.X > maxPosition.X || coordinates.Y > maxPosition.Y);
        } 
        public string ExposeData() => _position.X + " " + _position.Y + " " + _orientation.GetOrientationType();
    }
    
   
}