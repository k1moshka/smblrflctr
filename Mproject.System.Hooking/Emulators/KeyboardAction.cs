using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mproject.System.Messaging.Emulators
{
    public class KeyboardAction: IAction
    {
        #region virtual_codes
        private readonly IntPtr KEY_CTRL = new IntPtr(0x11);
        private readonly IntPtr KEY_X = new IntPtr(0x58);
        private readonly IntPtr KEY_V = new IntPtr(0x56);
        private readonly IntPtr KEY_A = new IntPtr(0x41);
        private readonly IntPtr KEY_B = new IntPtr(0x42);
        private readonly IntPtr KEY_C = new IntPtr(0x43);
        private readonly IntPtr KEY_D = new IntPtr(0x44);
        private readonly IntPtr KEY_E = new IntPtr(0x45);
        private readonly IntPtr KEY_F = new IntPtr(0x46);
        private readonly IntPtr KEY_G = new IntPtr(0x47);
        private readonly IntPtr KEY_H = new IntPtr(0x48);
        private readonly IntPtr KEY_I = new IntPtr(0x49);
        private readonly IntPtr KEY_J = new IntPtr(0x4A);
        private readonly IntPtr KEY_K = new IntPtr(0x4B);
        private readonly IntPtr KEY_L = new IntPtr(0x4C);
        private readonly IntPtr KEY_M = new IntPtr(0x4D);
        private readonly IntPtr KEY_N = new IntPtr(0x4E);
        private readonly IntPtr KEY_O = new IntPtr(0x4F);
        private readonly IntPtr KEY_P = new IntPtr(0x50);
        private readonly IntPtr KEY_Q = new IntPtr(0x51);
        private readonly IntPtr KEY_R = new IntPtr(0x52);
        private readonly IntPtr KEY_S = new IntPtr(0x53);
        private readonly IntPtr KEY_T = new IntPtr(0x54);
        private readonly IntPtr KEY_U = new IntPtr(0x55);
        private readonly IntPtr KEY_W = new IntPtr(0x57);
        private readonly IntPtr KEY_Y = new IntPtr(0x59);
        private readonly IntPtr KEY_Z = new IntPtr(0x5A);

        private readonly IntPtr KEY_1 = new IntPtr(0x31);
        private readonly IntPtr KEY_2 = new IntPtr(0x32);
        private readonly IntPtr KEY_3 = new IntPtr(0x33);
        private readonly IntPtr KEY_4 = new IntPtr(0x34);
        private readonly IntPtr KEY_5 = new IntPtr(0x35);
        private readonly IntPtr KEY_6 = new IntPtr(0x36);
        private readonly IntPtr KEY_7 = new IntPtr(0x37);
        private readonly IntPtr KEY_8 = new IntPtr(0x38);
        private readonly IntPtr KEY_9 = new IntPtr(0x39);
        private readonly IntPtr KEY_0 = new IntPtr(0x30);

        private readonly IntPtr KEY_ZAP = new IntPtr(188);
        private readonly IntPtr KEY_TOCH = new IntPtr(190);
        private readonly IntPtr KEY_SEP = new IntPtr(191);
        private readonly IntPtr KEY_TOCHZAP = new IntPtr(186);
        private readonly IntPtr KEY_OPOS = new IntPtr(222);
        private readonly IntPtr KEY_LEVKV = new IntPtr(219);
        private readonly IntPtr KEY_PRAVKV = new IntPtr(221);
        private readonly IntPtr KEY_SPACE = new IntPtr(0x20);
        private readonly IntPtr KEY_MINUS = new IntPtr(189);
        private readonly IntPtr KEY_PLUS = new IntPtr(187);
        private readonly IntPtr KEY_VERXSEP = new IntPtr(220);

        private readonly IntPtr KEY_SHIFT = new IntPtr(0x10);
        #endregion

        

        public int Msg
        {
            get;set;
        }

        public IntPtr WParam
        {
            get;set;
        }

        public IntPtr LParam
        {
            get {return IntPtr.Zero;} set {}
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

        public void SetUpAction(KeyEvent evnt, char key)
        {
            this.Msg = (int)evnt;

            var IsSpecial = false;
            var _SENDCHAR = IntPtr.Zero;
            switch (key)
            {
                case 'a':
                case 'ф': _SENDCHAR = KEY_A; break;
                case 'b':
                case 'и': _SENDCHAR = KEY_B; break;
                case 'c':
                case 'с': _SENDCHAR = KEY_C; break;
                case 'd':
                case 'в': _SENDCHAR = KEY_D; break;
                case 'e':
                case 'у': _SENDCHAR = KEY_E; break;
                case 'f':
                case 'а': _SENDCHAR = KEY_F; break;
                case 'g':
                case 'п': _SENDCHAR = KEY_G; break;
                case 'h':
                case 'р': _SENDCHAR = KEY_H; break;
                case 'i':
                case 'ш': _SENDCHAR = KEY_I; break;
                case 'j':
                case 'о': _SENDCHAR = KEY_J; break;
                case 'k':
                case 'л': _SENDCHAR = KEY_K; break;
                case 'l':
                case 'д': _SENDCHAR = KEY_L; break;
                case 'm':
                case 'ь': _SENDCHAR = KEY_M; break;
                case 'n':
                case 'т': _SENDCHAR = KEY_N; break;
                case 'o':
                case 'щ': _SENDCHAR = KEY_O; break;
                case 'p':
                case 'з': _SENDCHAR = KEY_P; break;
                case 'q':
                case 'й': _SENDCHAR = KEY_Q; break;
                case 'r':
                case 'к': _SENDCHAR = KEY_R; break;
                case 's':
                case 'ы': _SENDCHAR = KEY_S; break;
                case 't':
                case 'е': _SENDCHAR = KEY_T; break;
                case 'u':
                case 'г': _SENDCHAR = KEY_U; break;
                case 'v':
                case 'м': _SENDCHAR = KEY_V; break;
                case 'w':
                case 'ц': _SENDCHAR = KEY_W; break;
                case 'x':
                case 'ч': _SENDCHAR = KEY_X; break;
                case 'y':
                case 'н': _SENDCHAR = KEY_Y; break;
                case 'z':
                case 'я': _SENDCHAR = KEY_Z; break;
                case 'ю': _SENDCHAR = KEY_TOCH; break;

                case '1': _SENDCHAR = KEY_1; break;
                case '2': _SENDCHAR = KEY_2; break;
                case '3': _SENDCHAR = KEY_3; break;
                case '4': _SENDCHAR = KEY_4; break;
                case '5': _SENDCHAR = KEY_5; break;
                case '6': _SENDCHAR = KEY_6; break;
                case '7': _SENDCHAR = KEY_7; break;
                case '8': _SENDCHAR = KEY_8; break;
                case '9': _SENDCHAR = KEY_9; break;
                case '0': _SENDCHAR = KEY_0; break;

                case ',': _SENDCHAR = KEY_ZAP; break;
                case '.': _SENDCHAR = KEY_TOCH; break;
                case '/': _SENDCHAR = KEY_SEP; break;
                case ';': _SENDCHAR = KEY_TOCHZAP; break;
                case '"': _SENDCHAR = KEY_OPOS; break;
                case '[': _SENDCHAR = KEY_LEVKV; break;
                case ']': _SENDCHAR = KEY_PRAVKV; break;
                case ' ': _SENDCHAR = KEY_SPACE; break;

                //ENG-RASKLADKA
                case '!': _SENDCHAR = KEY_1; IsSpecial = true; break;
                case '@': _SENDCHAR = KEY_2; IsSpecial = true; break;
                case '#': _SENDCHAR = KEY_3; IsSpecial = true; break;
                case '$': _SENDCHAR = KEY_4; IsSpecial = true; break;
                case '%': _SENDCHAR = KEY_5; IsSpecial = true; break;
                case '^': _SENDCHAR = KEY_6; IsSpecial = true; break;
                case '&': _SENDCHAR = KEY_7; IsSpecial = true; break;
                case '*': _SENDCHAR = KEY_8; IsSpecial = true; break;
                case '(': _SENDCHAR = KEY_9; IsSpecial = true; break;
                case ')': _SENDCHAR = KEY_0; IsSpecial = true; break;
                case '_': _SENDCHAR = KEY_MINUS; IsSpecial = true; break;
                case '+': _SENDCHAR = KEY_PLUS; IsSpecial = true; break;
                case '|': _SENDCHAR = KEY_VERXSEP; IsSpecial = true; break;

                //RU-RASKLADKA
                case '№': _SENDCHAR = KEY_3; IsSpecial = true; break;
                case ':': _SENDCHAR = KEY_6; IsSpecial = true; break;
                case '?': _SENDCHAR = KEY_7; IsSpecial = true; break;
                case '-': _SENDCHAR = KEY_MINUS; IsSpecial = true; break;
                case '=': _SENDCHAR = KEY_PLUS; IsSpecial = true; break;
                case '\\': _SENDCHAR = KEY_VERXSEP; IsSpecial = true; break;
                default: break;

                this.WParam = _SENDCHAR;
            }
        }
    }
}
