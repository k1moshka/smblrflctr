using System.Collections.Generic;

namespace SymbolReflector.Core.Commands
{
    /// <summary>
    /// Класс обновляющий состояние всех хранимых команд
    /// </summary>
    public class CommandUpdater
    {
        private static List<UpdatableCommand> RegisteredCommands = new List<UpdatableCommand>();
        /// <summary>
        /// Добавление обновляемой команды
        /// </summary>
        /// <param name="command">Команда</param>
        public static void Register(UpdatableCommand command)
        {
            RegisteredCommands.Add(command);
        }
        /// <summary>
        /// Удаление команды
        /// </summary>
        /// <param name="command">Команда</param>
        public static void Release(UpdatableCommand command)
        {
            RegisteredCommands.Remove(command);
        }
        /// <summary>
        /// Обновление состояния всех хранимых команд
        /// </summary>
        public static void UpdateCommands()
        {
            foreach (var command in RegisteredCommands)
            {
                command.Update();
            }
        }
    }
}
