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
        private TransformNode _parent;
        //private ShapeNode _shape;
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
            else
                foreach (var child in _children)
                    child.FindNode(name, ref result);
        }

        public static void ShowAll()
        {
            foreach (var node in _rootNodes)
                node.ShowTree(0);
        }

        public void ShowTree() { ShowTree(0);}

        private void ShowTree(int depth)
        {
            var padding = "";
            padding = padding.PadLeft(depth * 2, '-');
            Console.WriteLine(padding + this);

            foreach (var child in _children)
            {
                child.ShowTree(depth+1);
            }
        }

        public void RemoveNode()
        {
            if (_parent != null) _parent._children.Remove(this);
            else _rootNodes.Remove(this);
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
