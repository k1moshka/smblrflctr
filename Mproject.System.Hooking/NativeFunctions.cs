using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, ushort dwFlags, IntPtr dwExtraINfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr ActivateKeyboardLayout(IntPtr HKL, int uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vkey);
    }
}
