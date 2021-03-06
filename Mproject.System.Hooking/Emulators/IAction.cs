﻿using System;

namespace Mproject.System.Messaging.Emulators
{
    /// <summary>
    /// Предоставление информации о действии
    /// </summary>
    public interface IAction
    {
        int Msg { get; set; }

        IntPtr WParam { get; set; }

        IntPtr LParam { get; set; }

        IntPtr Hwnd { get; set; }
    }
}
