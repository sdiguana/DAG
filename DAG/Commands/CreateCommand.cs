using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class CreateCommand : Command
    {
        public CreateCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            var output = string.Empty;
            var nodeName = string.Empty;

            nodeName = args.Length > 1 ? args[1] : args[0];
            

            switch (args[0])
            {
                case "sphere": output = new GeometryNode(nodeName).TransformNode.Name;
                    break;
                case "box": output = new GeometryNode(nodeName).TransformNode.Name;
                    break;
                case "light": output = new LightNode(nodeName).TransformNode.Name;
                    break;
            }

            return "created: " + output;
        }
    }
}
