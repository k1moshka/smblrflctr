using System;

namespace Mproject.System.Messaging
{
    /// <summary>
    /// Колбэк действия клаиши
    /// </summary>
    /// <param name="keyId">Код клавиши</param>
    public delegate void KeyActionCallback(int keyId);
    /// <summary>
    /// Колбэк описывающий действие происходящее при перехвате сообщения хуком
    /// </summary>
    /// <param name="nCode">Код сообщения</param>
    /// <param name="wParam">Дополнительная инфа сообщения</param>
    /// <param name="lParam">Дополнительная инфа сообщения</param>
    /// <returns>Описатель хука</returns>
    public delegate IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam); 

}
