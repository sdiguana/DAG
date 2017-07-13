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
            var na = new TransformNode();
            var nb = new TransformNode();
            var nc = new TransformNode();
            var nd = new TransformNode();
            var ne = new TransformNode();
            var nf = new TransformNode();

            nb.SetParent(na);
            nc.SetParent(na);
            nd.SetParent(nb);
            ne.SetParent(nc);
            nf.SetParent(nc);
            TransformNode.ShowAll();
            Console.WriteLine("reset nc to nd as parent");

            nc.SetParent(nd);
            TransformNode.ShowAll();
            Console.WriteLine("show nc children only");
            nc.ShowTree();

            Console.WriteLine("test grouping");
            TransformNode.Group(nd,nc);
            TransformNode.ShowAll();

            Console.WriteLine("test removing c");
            nc.RemoveNode();
            TransformNode.ShowAll();

            var foundNode = TransformNode.Find("B");
            if(foundNode!= null) Console.WriteLine("found: " + foundNode);

            Console.ReadKey();
        }
    }
}
