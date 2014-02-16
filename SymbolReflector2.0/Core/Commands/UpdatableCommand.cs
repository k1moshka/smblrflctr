using System;
using System.Windows.Input;

namespace SymbolReflector.Core.Commands
{
    /// <summary>
    /// Абстрактный класс команды, чье состояние обновляеться должно обновляться при экзекутах других команд
    /// </summary>
    public abstract class UpdatableCommand: ICommand
    {
        /// <summary>
        /// Проверка состояния команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>True - can, false - can't</returns>
        public abstract bool CanExecute(object parameter);
        /// <summary>
        /// Событие изменения состояния команды
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Экзекут команды
        /// </summary>
        /// <param name="parameter">Параметр для команды</param>
        public abstract void Execute(object parameter);
        /// <summary>
        /// Обновление состояния команды
        /// </summary>
        public virtual void Update()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
