using System;
using System.Runtime.InteropServices;

namespace Mproject.System.Messaging
{
    /// <summary>
    ///  Класс сожержит нативные функции для работы с хуками
    /// </summary>
    public static class NativeFunctions
    {
        /// <summary>
        /// Функция установки хука
        /// </summary>
        /// <param name="idHook">Описатель типа подключаемого хука</param>
        /// <param name="lpfn">Функция вызываемая при выполнении хука</param>
        /// <param name="hMod">Описатель текущего приложения</param>
        /// <param name="dwThreadId">Описатель потока</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallback lpfn, IntPtr hMod, uint dwThreadId);
        /// <summary>
        /// Функция отмены хука
        /// </summary>
        /// <param name="hhk">Дескриптор подключенного хука</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        /// <summary>
        /// Функция необходимая для вызова следующего в стэке хука
        /// </summary>
        /// <param name="hhk">Описатель хука начиная с которого необходимо продолжить опрос хуков</param>
        /// <param name="nCode">Код команды</param>
        /// <param name="wParam">Дополнительный параметр команды</param>
        /// <param name="lParam">Дополнительный параметр команды</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Получение дескриптора выполняющегося приложения
        /// </summary>
        /// <param name="lpModuleName">Имя процесса</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        /// <summary>
        /// Эмуляция нажатия или отжатия клавиши
        /// </summary>
        /// <param name="bVk">Код клавиши</param>
        /// <param name="bScan">Дополнительная информация</param>
        /// <param name="dwFlags">0 - down, 0x0002 - up</param>
        /// <param name="dwExtraINfo">Дополнительная информация</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, ushort dwFlags, IntPtr dwExtraINfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="HKL"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr ActivateKeyboardLayout(IntPtr HKL, int uFlags);
        /// <summary>
        /// Получения описателя активного окна системы
        /// </summary>
        /// <returns>HWND (Window Handler)</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// Отправляет сообщение окну в WinAPI формате
        /// </summary>
        /// <param name="hWnd">Описатель окна</param>
        /// <param name="Msg">Сообщение</param>
        /// <param name="wParam">Дополнительная информация</param>
        /// <param name="lParam">Дополнительная информация</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Возвращает состояние клавиши
        /// </summary>
        /// <param name="vkey">Код клавиши(WinAPI)</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vkey);
    }
}
