using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class LSCommand : Command
    {
        public LSCommand(string name) : base(name) { }

        public override string Process(string[] args)
        {
            string output = string.Empty;
            if (args.Length == 2)
            {
                var n = TransformNode.Find(args[1]) as TransformNode;
                if (n != null)
                {
                    Console.WriteLine(n);
                    n.ShowTree();
                }

                else
                    output = "invalid node specified: " + args[1];
            }

            else
            {
                Console.WriteLine("Scene");
                TransformNode.ShowAll();
            }
               

            return output;
        }
    }
}
