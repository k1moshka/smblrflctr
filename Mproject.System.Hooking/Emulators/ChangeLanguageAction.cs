using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mproject.System.Messaging.Emulators
{
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
