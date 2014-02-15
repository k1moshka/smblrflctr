using System;
using System.Windows;
using Mproject.System.Messaging.Filters;
using Mproject.System.Messaging;
using Settings = SymbolReflector.Properties.Settings;
using Mproject.System.Messaging.Emulators;
using System.Collections.Generic;

namespace SymbolReflector.Core
{
    internal class KeyboardFilterHandler
    {
        private static List<int> keyDowns = new List<int>();

        private static bool bind1down = false;
        private static bool bind2down = false;

        private static KeyActionCallback callback;
        private static KeyboardFilter filter;

        public static bool FilterApplied { get; set; }
        public static KeyboardFilter Filter
        {
            get
            { return filter ?? (filter = initFilter()); }
        }

        public static event EventHandler<EventArgs> BindDown;

        private static KeyboardFilter initFilter()
        {
            var _filter = new KeyboardFilter();
            callback = new KeyActionCallback(keyDownCallback);
            _filter.KeyDownCallback += new KeyActionCallback(keyDownCallback);
            _filter.KeyUpCallback += new KeyActionCallback(keyUpCallback);
            return _filter;
        }
        
        private static void keyDownCallback(int keyId)
        {
            if (keyId.Equals(Settings.Default.BindKey1) && !bind1down)
            {
                filter.AddKeyboardException(keyId);
                bind1down = true;
            }
            else if (keyId.Equals(Settings.Default.BindKey2) && bind1down && !bind2down)
            {
                filter.AddKeyboardException(keyId);
                bind2down = true;
                keyDowns.Add(Settings.Default.BindKey1);
                keyDowns.Add(keyId);
            }
        }

        private static void keyUpCallback(int keyId)
        {
            if (keyDowns.Contains(keyId))
            {
                keyDowns.Remove(keyId);
                if (keyDowns.Count.Equals(0))
                    invokeEvent();
            }
        }

        private static void invokeEvent()
        {
            bind1down = bind2down = false;
            if (BindDown != null)
                BindDown(null, new EventArgs());
        }
    }
}
