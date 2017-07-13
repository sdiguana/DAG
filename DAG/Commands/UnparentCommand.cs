using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class UnparentCommand : Command
    {
        public UnparentCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;
            if (args.Length == 2)
            {
                var node = TransformNode.Find(args[1]) as TransformNode;
                if (node != null)
                    node.SetParent(null);
                else
                    output = "Node not found: " + node;
            }
            else
            {
                output = "you must specify a single node";
            }

            return output;
        }
    }
}
