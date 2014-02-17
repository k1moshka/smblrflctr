using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SymbolReflector.Core.UI.Commands
{
    /// <summary>
    /// WPF-команда установки дефолтных настроек для байнда
    /// </summary>
    public class ResetBindSettingsCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var binder = parameter as Binder;
            binder.ResetBind();
        }
    }
}
