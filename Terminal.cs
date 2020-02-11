using System;
using System.Security;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace Dependency
{
    public class Terminal : ITerminal
    {
        public bool Exited { get; }
        private string _promptString;

        public Terminal()
        {
            _promptString = String.Format("{0}$ ", WindowsIdentity.GetCurrent().Name);
            Exited = false;
        }

        public Command PromptCommand()
        {
            string commandLine = Prompt();
            return new Command(commandLine);
        }

        public string Prompt()
        {
            Console.Write(_promptString);
            string userCommand = Console.ReadLine();
            return userCommand;
        }

        public void ExecuteCommand(Command command)
        {
            try
            {
                command.Launch();
                if (command.Output.Length > 0)
                {
                    Console.WriteLine(command.Output);
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.Error.WriteLine("{0}: path not found", command);
            }
        }
    }
}
