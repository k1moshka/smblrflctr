using System;

namespace Mproject.System.Messaging.Emulators
{
    /// <summary>
    /// Событие смены ракладки клавиатуры для активного окна
    /// </summary>
    public class ChangeLanguageAction: IAction
    {
        public int Msg
        {
            get
            {
                return 0x0050;
            }
            set
            {
                
            }
        }

        public IntPtr WParam
        {
            get
            {
                return new IntPtr(0x0002);
            }
            set
            {
                
            }
        }

        public IntPtr LParam
        {
            get
            {
                return IntPtr.Zero;
            }
            set
            {
                
            }
        }

        public IntPtr Hwnd
        {
            get
            {
                return NativeFunctions.GetForegroundWindow();
            }
            set
            {

            }
        }
    }
}
