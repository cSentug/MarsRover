using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Autofac;
using MarsRover.Core.Instruction;
using MarsRover.Core.Orientation;
using MarsRover.Core.Plateau;
using MarsRover.Core.Rover;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            #region Input Sequence
            
            var plateauRegex = new Regex("\\d\\s\\d$");
            string plateauInfo = "";
            Console.WriteLine("Enter plateau size. ex: 5 5");
            do
            {
                plateauInfo = Console.ReadLine();
            }while(!plateauRegex.IsMatch(plateauInfo));
            
            
            var roverRegex = new Regex("^\\d\\s\\d\\s\\b[N,S,W,E]$");
            string roverOneInfo = "";
            Console.WriteLine("Enter RoverOne start point and compass sign. ex: 1 2 N");
            do
            {
                roverOneInfo = Console.ReadLine();
            }while(!roverRegex.IsMatch(roverOneInfo));
            
            
            var roverOneInstructions = "";
            Console.WriteLine("Enter RoverOne orders. ex:LMLMLMLMM");
            do
            {
                roverOneInstructions = Console.ReadLine();
            } while (roverOneInstructions.Any(x => x != 'L' && x != 'M' && x != 'R'));
            
            
            var roverTwoInfo = "";
            Console.WriteLine("Enter RoverTwo start point and compass sign. ex: 3 3 E");
            do
            {
                roverTwoInfo = Console.ReadLine();
            }while(!roverRegex.IsMatch(roverTwoInfo));
            
            
            Console.WriteLine("Enter RoverTwo instructions. ex:MMRMMRMRRM");
            var roverTwoInstructions = "";
            do
            {
                roverTwoInstructions = Console.ReadLine();
            } while (roverTwoInstructions.Any(x => x != 'L' && x != 'M' && x != 'R'));

            

            #endregion input sequence
            
            #region Parsing Inputs  
            var x = Convert.ToInt32(plateauInfo.Split(" ")[0]);
            var y = Convert.ToInt32(plateauInfo.Split(" ")[1]);

            var RoverOneX = Convert.ToInt32(roverOneInfo.Split(" ")[0]);
            var RoverOneY = Convert.ToInt32(roverOneInfo.Split(" ")[1]);
            var RoverOneOrientation = roverOneInfo.Split(" ")[2];

            var RoverTwoX = Convert.ToInt32(roverTwoInfo.Split(" ")[0]);
            var RoverTwoY = Convert.ToInt32(roverTwoInfo.Split(" ")[1]);
            var RoverTwoOrientation = roverTwoInfo.Split(" ")[2];
            #endregion Parsing imputs
            
            //create items by inputs
            IPlateau plateau = new Plateau(x,y);
            IRover roverOne = new Rover(RoverOneX,RoverOneY,plateau);
            IRover roverTwo = new Rover(RoverTwoX,RoverTwoY,plateau);

            //create roverInstructions
            List<IInstruction> _tempRoverOneInstructions = new List<IInstruction>();
            List<IInstruction> _tempRoverTwoInstructions = new List<IInstruction>();
            
            
            //Resolving container configs and filling roverInstructions
            using (var scope = container.BeginLifetimeScope())
            {
                foreach (var instruction in roverOneInstructions)
                {
                    var roverInstruction = container.Resolve<IInstruction>(new NamedParameter("instruction", instruction));
                    _tempRoverOneInstructions.Add(roverInstruction);
                }
                roverOne.UpdateInstructions(_tempRoverOneInstructions);
                
                foreach (var instruction in roverTwoInstructions)
                {
                    var roverCommand = container.Resolve<IInstruction>(new NamedParameter("instruction", instruction));
                    _tempRoverTwoInstructions.Add(roverCommand);
                }
                roverTwo.UpdateInstructions(_tempRoverTwoInstructions);
                
                
                var rover1Orientation = container.Resolve<IOrientation>(new NamedParameter("orientation", RoverOneOrientation));
                roverOne.UpdateOrientation(rover1Orientation);
                
                var rover2Orientation = container.Resolve<IOrientation>(new NamedParameter("orientation", RoverTwoOrientation));
                roverTwo.UpdateOrientation(rover2Orientation);
            }

            //Move one by one
            roverOne.MoveRover();
            roverTwo.MoveRover();
        }
    }
}