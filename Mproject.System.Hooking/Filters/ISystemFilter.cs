using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mproject.System.Messaging.Filters
{
    /// <summary>
    /// Предоставляет данные для подклбчения системного хука
    /// </summary>
    public interface ISystemFilter
    {
        /// <summary>
        /// Показывает подключен ли хук в систему
        /// </summary>
        bool IsActive { get; set; }
        /// <summary>
        /// Дескриптор подключенного хука
        /// </summary>
        IntPtr IdHook { get; set; }
        /// <summary>
        /// Дескриптор типа хука
        /// </summary>
        int IdTypeHook { get; }
        /// <summary>
        /// Делегат действия просиходящего при выполнения хука
        /// </summary>
        HookCallback HookCallback { get; }
    }
}
