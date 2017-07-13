using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class ClearCommand : Command
    {
        public ClearCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            if (args.Length > 1)
                return "Clear Requires no additional arguments.";

            Console.Clear();
            return string.Empty;
        }
    }
}
