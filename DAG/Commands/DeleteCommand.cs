using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class DeleteCommand : Command
    {
        public DeleteCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;
            if (args.Length == 2)
            {
                var n = TransformNode.Find(args[1]) as TransformNode;
                n?.RemoveNode();
                if (n == null)
                    output = "node not found: " + args[1];
            }
            else
                output = "invalid delete command. enter a single node to delete";


            return output;
        }
    }
}
