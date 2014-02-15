using System;
using System.Windows.Input;
using Mproject.System.Messaging;

namespace SymbolReflector.Core.Commands
{
    public class RemoveSystemFilterCommand: UpdatableCommand
    {
        public event EventHandler CanExecuteChanged;

        public RemoveSystemFilterCommand()
        {
            CommandUpdater.Register(this);
        }

        ~RemoveSystemFilterCommand()
        {
            CommandUpdater.Release(this);
        }

        public override bool CanExecute(object parameter)
        {
            if (KeyboardFilterHandler.FilterApplied)
                return true;
            return false;
        }

        public override void Execute(object parameter)
        {
            FilterConnector.Instance.RemoveFilter(KeyboardFilterHandler.Filter);
            KeyboardFilterHandler.FilterApplied = false;
            CommandUpdater.UpdateCommands();
        }
    }
}
