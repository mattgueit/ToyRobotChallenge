using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge.Simulation
{
    public interface ISimulator
    {
        void ExecuteRobotCommands(List<string> commands);
    }
}
