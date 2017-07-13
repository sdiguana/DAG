using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class RenameCommand : Command
    {
        public RenameCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;
            if (args.Length == 3)
            {
                var nOld = TransformNode.Find(args[1]);
                if (nOld != null)
                    if (TransformNode.Find(args[2]) == null)
                        nOld.Name = args[2];
                    else
                        output = "target name already exists: " + args[2];
                else
                    output = "node not found";
            }
            else
                output = "an old name and new name must be specified";

            return output;
        }
    }
}
