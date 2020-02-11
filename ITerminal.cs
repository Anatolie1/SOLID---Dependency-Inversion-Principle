using System;
using System.Collections.Generic;
using System.Text;

namespace Dependency
{
    public interface ITerminal
    {
        public bool Exited { get; }
        public Command PromptCommand();
        public void ExecuteCommand(Command command);
    }
}