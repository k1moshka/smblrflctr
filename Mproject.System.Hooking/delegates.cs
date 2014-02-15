using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mproject.System.Messaging
{
    public delegate void KeyActionCallback(int keyId);
    public delegate IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam); 

}
