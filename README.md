# ToyRobotChallenge
The Toy Robot Challenge is a simulation of a toy robot navigating on a 5 x 5 unit table top. The robot moves based on the commands it has been given.
### Rules
Only the following commands can be used:
**PLACE X,Y,F**
**MOVE**
**LEFT**
**RIGHT**
**REPORT**

. **PLACE** will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
. The origin (0,0) can be considered to be the SOUTH WEST most corner.
. The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
. **MOVE** will move the toy robot one unit forward in the direction it is currently facing.
. **LEFT** and **RIGHT** will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
. **REPORT** will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.

. A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.
. Input comes from a text file.

Constraints:
The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot.
Any move that would cause the robot to fall must be ignored.


### Installation and usage
Download the source code.
Navigate to the application's root directory (..\ToyRobotChallenge) in a command-line shell of your choice.
Execute the command below:
```sh
dotnet build --configuration Release
```


Navigate to:
```sh
...\ToyRobotChallenge\ToyRobotChallenge\bin\Release\net5.0\
```

Create or place a text file in this directory containing desired commands.

Then execute the application in your command-line shell using the following format:
```sh
.\ToyRobotChallenge.exe -f YourCommandFile.txt
```