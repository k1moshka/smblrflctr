using System;
using System.Windows.Input;

namespace SymbolReflector.Core.UI.Commands
{
    /// <summary>
    /// Команда сокрытия окна
    /// </summary>
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
