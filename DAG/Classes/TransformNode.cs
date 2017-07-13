using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class TransformNode : Node
    {
        //Fields
        private const int TREE_DRAW_OFFSET = 4;
        private const char CHAR_HLINE = (char) 0x2500;
        private const char CHAR_VLINE = (char)0x2502;
        private const char CHAR_TJOINT = (char)0x251C;
        private const char CHAR_ANGLE = (char)0x2514;

        private TransformNode _parent;
        private ShapeNode _shape;
        private static List<TransformNode> _rootNodes  = new List<TransformNode>();

        private List<TransformNode> _children = new List<TransformNode>();

        //Properties

        //CTOR
        public TransformNode() : this("Transform") { }

        public TransformNode(string name)
        {
            var validatedName = name;
            var counter = 2;
            while (Find(validatedName) != null)
            {
                validatedName = name + counter.ToString();
                counter++;
            }

            this.Name = validatedName;
            _rootNodes.Add(this);
        }

        //Methods
        public void SetParent(TransformNode parent)
        {
            //remove from old parent's children list
            if (_parent == null) { _rootNodes.Remove(this); }
            else { _parent._children.Remove(this); }

            //assign new parent
            _parent = parent;
            if (parent == null) { _rootNodes.Add(this); }
            else { _parent._children.Add(this); }
        }

        public void SetShape(ShapeNode shape) => _shape = shape;

        public static Node Find(string name) => _rootNodes.Select(node => node.FindNode(name)).FirstOrDefault(result => result != null);

        public Node FindNode(string name)
        {
            Node result = null;
            FindNode(name, ref result);
            return result;
        }

        private void FindNode(string name, ref Node result)
        {
            if (Name == name) result = this;
            else if (_shape != null && _shape.Name == name)
                result = _shape;
            else
                foreach (var child in _children)
                    child.FindNode(name, ref result);
        }

        public static void ShowAll()
        {
           // foreach (var node in _rootNodes)
           //     node.ShowTree(0);
           ShowTree(_rootNodes,"");
        }

        public void ShowTree()
        {
            //ShowTree(0);
            ShowTree(_children,"");
        }

        private static void ShowTree(List<TransformNode> nodes, string padding)
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                var sb = new StringBuilder();
                var pb = new StringBuilder();

                sb.Append(padding);
                pb.Append(padding);

                if (i < nodes.Count - 1)
                {
                    sb.Append(CHAR_TJOINT);

                    pb.Append(CHAR_VLINE);
                    pb.Append(' ', TREE_DRAW_OFFSET - 1);
                }
                else
                {
                    sb.Append(CHAR_ANGLE);
                    pb.Append(' ', TREE_DRAW_OFFSET);
                }
                sb.Append(CHAR_HLINE, TREE_DRAW_OFFSET - 1);
                sb.AppendFormat("{0} [{1}]", nodes[i], nodes[i]._shape);

                Console.WriteLine(sb.ToString());
                ShowTree(nodes[i]._children, pb.ToString());
            }
            
        }

        
        private void ShowTree(int depth)
        {
            var padding = "";
            padding = padding.PadLeft(depth * 2, '-');
            Console.WriteLine(padding + this + "[" + _shape + "]");

            foreach (var child in _children)
            {
                child.ShowTree(depth+1);
            }
        }
        
        public void RemoveNode()
        {
            RemoveShape();   
            if (_parent != null) _parent._children.Remove(this);
            else _rootNodes.Remove(this); 
        }

        private void RemoveShape()
        {
            ShapeNode.RemoveNode(_shape);
            foreach (var child in _children)
                child.RemoveShape();
        }

        public static void Group(TransformNode nodeA, TransformNode nodeB)
        {
            var groupNode = new TransformNode("Group");
            nodeA.SetParent(groupNode);
            nodeB.SetParent(groupNode);
        }

        public static void Group(TransformNode nodeA)
        {
            var groupNode = new TransformNode("Group");
            nodeA.SetParent(groupNode);
        }
    }
}
