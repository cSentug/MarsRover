using Autofac;
using MarsRover.Core.Instruction;
using MarsRover.Core.Orientation;

namespace MarsRover
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            builder.Register<IOrientation>(
                (c, p) =>
                {
                    var orientation = p.Named<string>("orientation");
                    if (orientation.Equals("E"))
                    {
                        return new EOrientation();
                    }
                    if(orientation.Equals("S"))
                    {
                        return new SOrientation();
                    }
                    if(orientation.Equals("N"))
                    {
                        return new NOrientation();
                    }
                    if(orientation.Equals("W"))
                    {
                        return new WOrientation();
                    }
                    return null;
                });
            
            builder.Register<IInstruction>(
                (c, p) =>
                {
                    var instruction = p.Named<char>("instruction");
                    
                    if (instruction.Equals('L'))
                    {
                        return new TurnLeftInstruction();
                    }
                    if(instruction.Equals('R'))
                    {
                        return new TurnRightInstruction();
                    }
                    if(instruction.Equals('M'))
                    {
                        return new MoveTowardsInstruction();
                    }
                    return null;
                });
            return builder.Build();
        }
    }

    
}