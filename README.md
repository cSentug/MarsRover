# MarsRover
-
There're many unmentioned parts of story. So i wanted to stick with
SOLID princibles as much as possible. Also aimed to %100 code covarage for core layer. 

So we need to have a plateau and rover.
plateau has a simple interface with getSize.

But rover is a bit more complex. 
We have some defined inputs. 
- Position
- Orientation
- Instructions
Full of input example is : 
1 2 N
LMLMLMLMM

So we need Get/UpdateOrientation and Get/UpdateInstructions methods.

In this case,
I created IIntroduction and IOrientation contracts and derived classes from them.
I used autofac package for configuring those derive rules in ContainerConfig.cs.
By this way Our core layer is extendable.Now we don't need to make any modification 
on our core layer. All we need to do modify our ContainerConfig.cs and new derived 
class from related contract.

Does rover really needs to know plateau?
I think it should since if move is not in plateau it should not go there.
So,
I wrote a private method in rover which worries about if given coordinates in plateau.

In some of unit tests i took help of input collections




