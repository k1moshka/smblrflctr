using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Mproject.System.Messaging.Filters
{
    public class KeyboardFilter: ISystemFilter
    {
        private HookCallback hookCallback;
        private const int WH_KEYDOWN = 0x0100;
        private const int WH_KEYUP = 0x0101;
        private const int ID_TYPE_HOOK = 13;
        private readonly List<int> KEYBOARD_EXCEPTION = new List<int>();

        private KeyActionCallback _keyDownCallback;
        private KeyActionCallback _keyUpCallback;

        /// <summary>
        /// Подключен ли хук в систему
        /// </summary>
        public bool IsActive
        {
            get;
            set;
        }
        /// <summary>
        /// Дескриптор подключенного хука
        /// </summary>
        public IntPtr IdHook
        {
            get;set;
        }
        /// <summary>
        /// Дескриптор типа хука
        /// </summary>
        public int IdTypeHook
        {
            get { return ID_TYPE_HOOK; }
        }
        /// <summary>
        /// Делегат действия просиходящего при выполнения хука
        /// </summary>
        public HookCallback HookCallback
        {
            get
            {
                return this.hookCallback;
            }
        }

        public KeyboardFilter()
        {
            this.hookCallback = new HookCallback(_hookCallBack);
        }

        /// <summary>
        /// Событие нажатия на кнопку
        /// </summary>
        public KeyActionCallback KeyDownCallback
        {
            get { return _keyDownCallback; }
            set { _keyDownCallback = value; }
        }

        public KeyActionCallback KeyUpCallback
        {
            get { return _keyUpCallback; }
            set { _keyUpCallback = value; }
        }

        #region изменение исключаемых кодов
        /// <summary>
        /// Добавление кода который не будет передоваться в следующие хуки
        /// </summary>
        /// <param name="keyId">Код кодманды</param>
        public void AddKeyboardException(int keyId)
        {
            KEYBOARD_EXCEPTION.Add(keyId);
        }
        /// <summary>
        /// Добавление исключительного кода
        /// </summary>
        /// <param name="keyId">Код кодманды</param>
        public void RemoveKeyboardException(int keyId)
        {
            KEYBOARD_EXCEPTION.Remove(keyId);
        }
        /// <summary>
        /// Удаление всех исключительных кодов
        /// </summary>
        public void ClearKeyboardExceptions()
        {
            KEYBOARD_EXCEPTION.Clear();
        }
        #endregion
        /// <summary>
        /// Обработка события порожденного хуком
        /// </summary>
        private IntPtr _hookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // TODO: уменьшить сложность метода
            if (nCode >= 0)
            {
                var symbol = Marshal.ReadInt32(lParam);

                if (wParam == (IntPtr)WH_KEYDOWN)
                {
                    if (_keyDownCallback != null)
                        _keyDownCallback(symbol);
                }
                else
                {
                    if (_keyUpCallback != null)
                        _keyUpCallback(symbol);
                }


                if (KEYBOARD_EXCEPTION.Contains(symbol))
                    return new IntPtr(1);
                    //return NativeFunctions.CallNextHookEx(IdHook, 0x00, IntPtr.Zero, IntPtr.Zero); //IntPtr.Zero;
            }
            return NativeFunctions.CallNextHookEx(IdHook, nCode, wParam, lParam);
        }
    }
}
