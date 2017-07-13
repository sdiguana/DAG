using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
    public static class CommandManager
    {
        //Fields
        private static List<Command> commandList = new List<Command>();
        public static bool DoneRunning = false;
        //Properties
        //CTOR
        static CommandManager()
        {
            commandList.Add(new ClearCommand("clear"));
            commandList.Add(new ExitCommand("exit"));
            commandList.Add(new LSCommand("ls"));
            commandList.Add(new CreateCommand("sphere"));
            commandList.Add(new CreateCommand("box"));
            commandList.Add(new CreateCommand("light"));
            commandList.Add(new DeleteCommand("delete"));
            commandList.Add(new ParentCommand("parent"));
            commandList.Add(new UnparentCommand("unparent"));
            commandList.Add(new GroupCommand("group"));
            commandList.Add(new RenameCommand("rename"));
        }
        //Methods
        public static void ProcessCommand(string input)
        {
            var args = input.Split(' ');
            if (args.Length <= 0) return;
            string output = null;
            var i = 0;
            for(; i < commandList.Count;i++)
            {
                if (commandList[i].CommandName != args[0]) continue;

                output = commandList[i].Process(args);
                break;
            }

            if(i == commandList.Count)
                Console.WriteLine("invalid command.");

            else if(output!=null) Console.WriteLine(output);
        }
    }
}
