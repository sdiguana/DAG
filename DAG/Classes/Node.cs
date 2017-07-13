using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public class Node
    {
        //Fields
        protected string _name;
        //Properties
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        //CTOR

        //Methods
        public override string ToString() => this._name;
    }
}
