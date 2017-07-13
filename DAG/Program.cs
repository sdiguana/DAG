using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TransformNode("a");
            var b = new TransformNode("b");
            var c = new TransformNode("c");
            var d = new TransformNode("d");
            var e = new TransformNode("e");
            var f = new TransformNode("f");
            var g = new TransformNode("g");
            var h = new TransformNode("h");
            b.SetParent(a);
            c.SetParent(b);
            e.SetParent(d);
            f.SetParent(d);
            g.SetParent(d);
            h.SetParent(f);

            CommandManager.ProcessCommand("ls");

            while (!CommandManager.DoneRunning)
            {
                Console.Write(":");
                CommandManager.ProcessCommand(Console.ReadLine());
            }

        }
    }
}
