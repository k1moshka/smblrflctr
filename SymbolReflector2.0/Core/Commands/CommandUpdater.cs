using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SymbolReflector.Core.Commands
{
    public class CommandUpdater
    {
        private static List<UpdatableCommand> RegisteredCommands = new List<UpdatableCommand>();

        public static void Register(UpdatableCommand command)
        {
            RegisteredCommands.Add(command);
        }

        public static void Release(UpdatableCommand command)
        {
            RegisteredCommands.Remove(command);
        }

        public static void UpdateCommands()
        {
            foreach (var command in RegisteredCommands)
            {
                command.Update();
            }
        }
    }
}
