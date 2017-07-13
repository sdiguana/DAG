using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class ShapeNode : Node
    {
        //Fields
        private static List<ShapeNode> _shapes = new List<ShapeNode>();
        private TransformNode _transformNode;

        //Properties
        public TransformNode TransformNode => _transformNode;

        //CTOR
        public ShapeNode(string name)
        {
            _transformNode = new TransformNode(name);
            _transformNode.SetShape(this);
            Name = _transformNode.Name + "Shape";
            _shapes.Add(this);
        }

        //Methods
        public static void ShowAll()
        {
            foreach (var shape in _shapes)
                Console.WriteLine(shape + " [" + shape._transformNode + "]" );
        }

        public static void RemoveNode(ShapeNode node) => _shapes.Remove(node);
    }
}
