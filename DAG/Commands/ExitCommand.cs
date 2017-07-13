using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class ExitCommand : Command
    {
        public ExitCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;

            if (args.Length > 0)
                output = "too many params";

            CommandManager.DoneRunning = true;

            return output;
        }
    }
}
