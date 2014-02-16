using System;

namespace Mproject.System.Messaging.Emulators
{
    /// <summary>
    /// Эмулятор действий пользователя над окном
    /// </summary>
    public class Emulator
    {
        #region singleton
        private static Emulator _instance;
        /// <summary>
        /// Экземпляр эмулятора
        /// </summary>
        public static Emulator Instance
        {
            get { return _instance ?? (_instance = new Emulator()); }
        }
        private Emulator() { }
        #endregion

        /// <summary>
        /// Эмулирует действие пользователя над активным окном
        /// </summary>
        /// <param name="action">Информация об действии которое нужно сэмулировать</param>
        public void Emulate(IAction action)
        {
            NativeFunctions.SendMessage(action.Hwnd, action.Msg, action.WParam, action.LParam);
        }
        /// <summary>
        /// Эмулирует действие клавиатуры над активным окном
        /// </summary>
        /// <param name="keyAction"></param>
        public void EmulateKey(IAction keyAction)
        {
            NativeFunctions.keybd_event((byte)keyAction.WParam, 0, (ushort)(keyAction.Msg.Equals(0x0100) ? 0 : 0x0002), IntPtr.Zero);
        }
    }
}
