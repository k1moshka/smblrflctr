using System;
using Mproject.System.Messaging.Filters;
using Mproject.System.Messaging;
using Settings = SymbolReflector.Properties.Settings;
using System.Collections.Generic;

namespace SymbolReflector.Core
{
    /// <summary>
    /// Класс упраляющий и обрабатывающий действия клавиатуры
    /// </summary>
    internal class KeyboardFilterHandler
    {
        private static List<int> keyDowns = new List<int>();

        private static bool bind1down = false;
        private static bool bind2down = false;

        private static KeyActionCallback callback;
        private static KeyboardFilter filter;

        /// <summary>
        /// Подключен ли фильтр в систему
        /// </summary>
        public static bool FilterApplied { get; set; }

        /// <summary>
        /// Возвращает рабочий фильтрор
        /// </summary>
        public static KeyboardFilter Filter
        {
            get
            { return filter ?? (filter = initFilter()); }
        }
        /// <summary>
        /// Событие нажатия байнда
        /// </summary>
        public static event EventHandler<EventArgs> BindDown;

        private static KeyboardFilter initFilter()
        {
            // инициализация рабочего экземпляра фильтра
            var _filter = new KeyboardFilter();
            callback = new KeyActionCallback(keyDownCallback);
            _filter.KeyDownCallback += new KeyActionCallback(keyDownCallback);
            _filter.KeyUpCallback += new KeyActionCallback(keyUpCallback);
            return _filter;
        }
        
        private static void keyDownCallback(int keyId)
        {
            // обработка события нажатия клавиши
            if (keyId.Equals(Settings.Default.BindKey1) && !bind1down)
            {
                filter.AddKeyboardException(keyId);
                bind1down = true;
            }
            else if (keyId.Equals(Settings.Default.BindKey2) && bind1down && !bind2down)
            {
                // детект нажатия обеих клавиш байнда
                filter.AddKeyboardException(keyId);
                bind2down = true;
                keyDowns.Add(Settings.Default.BindKey1);
                keyDowns.Add(keyId);
            }
        }

        private static void keyUpCallback(int keyId)
        {
            // обработка события поднятия клавиши
            // детект нажатия байнда
            if (keyDowns.Contains(keyId))
            {
                keyDowns.Remove(keyId);
                if (keyDowns.Count.Equals(0))
                    invokeEvent();
            }
        }

        private static void invokeEvent()
        {
            // вызов подписчиков события нажатия байнда
            bind1down = bind2down = false;
            if (BindDown != null)
                BindDown(null, new EventArgs());
        }
    }
}
