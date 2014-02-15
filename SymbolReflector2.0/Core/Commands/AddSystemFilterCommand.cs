using System;
using System.Windows.Input;
using Mproject.System.Messaging;

namespace SymbolReflector.Core.Commands
{
    public class AddSystemFilterCommand: UpdatableCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddSystemFilterCommand()
        {
            CommandUpdater.Register(this);
        }

        ~AddSystemFilterCommand()
        {
            CommandUpdater.Release(this);
        }

        public override bool CanExecute(object parameter)
        {
            if (KeyboardFilterHandler.FilterApplied)
                return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            FilterConnector.Instance.ApplyFilter(KeyboardFilterHandler.Filter);
            
            KeyboardFilterHandler.FilterApplied = true;
            CommandUpdater.UpdateCommands();
        }
    }
}
