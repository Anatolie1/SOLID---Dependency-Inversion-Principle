using System;

namespace Dependency
{
    public class Program
    {
        public static void Main()
        {
            ITerminal terminal = new Terminal();
            while (!terminal.Exited)
            {
                Command command = terminal.PromptCommand();

                terminal.ExecuteCommand(command);
            }
        }
    }
}
