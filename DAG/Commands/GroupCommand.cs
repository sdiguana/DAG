using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class GroupCommand : Command
    {
        public GroupCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;
            if (args.Length == 3)
            {
                var n1 = TransformNode.Find(args[1]) as TransformNode;
                var n2 = TransformNode.Find(args[2]) as TransformNode;
                if (n1 != null && n2 != null)
                    TransformNode.Group(n1, n2);
                else
                    output = "one or both nodes are not found";
            }
            else if (args.Length == 2)
            {
                var n1 = TransformNode.Find(args[1]) as TransformNode;
                if (n1 != null)
                    TransformNode.Group(n1);
                else
                    output = "the node specified is not valid";
            }
            else
                output = "you must specify 1, or 2 nodes in order to group";

            return output;
        }
    }
}
