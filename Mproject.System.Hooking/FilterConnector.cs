using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mproject.System.Messaging.Filters;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Mproject.System.Messaging
{
    public class FilterConnector // singleton
    {
        #region singleton
        private static FilterConnector _instance;
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public static FilterConnector Instance 
        { 
            get 
            { 
                return _instance ?? (_instance = new FilterConnector()); 
            } 
        }

        private FilterConnector()
        {
            _activeFilters = new List<KeyboardFilter>();
        }
        #endregion

        private readonly List<KeyboardFilter> _activeFilters;

        /// <summary>
        /// Добавляет фильтр в систему
        /// </summary>
        /// <param name="filter">Информация о фильтре, который необходимо подключить</param>
        public void ApplyFilter(KeyboardFilter filter)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                filter.IdHook = NativeFunctions.SetWindowsHookEx(filter.IdTypeHook, filter.HookCallback,
                                            NativeFunctions.GetModuleHandle(curModule.ModuleName), 0); // нативное добавление хука в систему
            }
            filter.IsActive = true; // флаг активности хука
            _activeFilters.Add(filter);
        }
        /// <summary>
        /// Удаление фильтра из системы
        /// </summary>
        /// <param name="filter">Фильтр который необходимо удалить</param>
        public void RemoveFilter(KeyboardFilter filter)
        {
            if (!filter.IsActive) throw new Exception("Фильтр не зарегистриован в системе");
            
            if (!NativeFunctions.UnhookWindowsHookEx(filter.IdHook)) // нативное удаление хука из систему
                throw new Exception("Хук не был удален из системы. Возможно он не был подключен.");
           
            filter.IsActive = false;
            _activeFilters.Remove(filter);
        }
    }
}
