using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public abstract class Command
    {
        private string _commandName;
        public string CommandName => _commandName;


        public Command(string name)
        {
            _commandName = name;
        }

        public abstract string Process(string[] args);
    }
}
