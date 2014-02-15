using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SymbolReflector.Core.Commands
{
    public abstract class UpdatableCommand: ICommand
    {
        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);

        public virtual void Update()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
