using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SymbolReflector.Core.UI.Commands
{
    public class HideWindowCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return App.Current.MainWindow != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            App.Current.MainWindow.Hide();
        }
    }
}
