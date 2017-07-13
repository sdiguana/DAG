using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class ParentCommand : Command
    {
        public ParentCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;
            if (args.Length == 3)
            {
                var child = TransformNode.Find(args[1]) as TransformNode;
                var parent = TransformNode.Find(args[2]) as TransformNode;
                if(child != null && parent != null)
                    if (child.FindNode(parent.Name) == null)
                        child.SetParent(parent);
                    else
                        output =
                            "Cannot set parent as a child to the specified child, because the child is already a child of the parent";
                else
                output = "Parenting failed. Could not find one, or both nodes.";
            }
            else
            {
                output = "you must specify two nodes";
            }

            return output;
        }
    }
}
