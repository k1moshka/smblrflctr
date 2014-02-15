using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mproject.System.Messaging.Emulators;
using Mproject.System.Messaging;
using System.Threading;

namespace SymbolReflector.Core
{
    public class StringChanger
    {
        private Emulator emul = Emulator.Instance;
        private KeyboardAction ctrl_d;
        private KeyboardAction v_d;
        private KeyboardAction x_d;
        private KeyboardAction ctrl_u;
        private KeyboardAction v_u;
        private KeyboardAction x_u;
        private KeyboardAction shift_d;
        private KeyboardAction shift_u;

        public StringChanger()
        {
            ctrl_d = new KeyboardAction()
            {
                Msg = 0x0100,
                WParam = new IntPtr(0x11)
            }; // ctrl down
            v_d = new KeyboardAction()
            {
                Msg = 0x0100,
                WParam = new IntPtr(0x56)
            }; // v down
            x_d = new KeyboardAction()
            {
                Msg = 0x0100,
                WParam = new IntPtr(0x58)
            }; // x down

            ctrl_u = new KeyboardAction()
            {
                Msg = 0x0101,
                WParam = new IntPtr(0x11)
            }; // ctrl up
            v_u = new KeyboardAction()
            {
                Msg = 0x0101,
                WParam = new IntPtr(0x56)
            }; // v up
            x_u = new KeyboardAction()
            {
                Msg = 0x0101,
                WParam = new IntPtr(0x58)
            }; // x up
            shift_d = new KeyboardAction()
            {
                Msg = 0x0100,
                WParam = new IntPtr(0x10)
            }; // x up
            shift_u = new KeyboardAction()
            {
                Msg = 0x0101,
                WParam = new IntPtr(0x10)
            }; // x up
        }

        private void changeLang()
        {
            emul.Emulate(new ChangeLanguageAction());
        }

        public void Cut()
        {
            // d - down, u - up
            emul.EmulateKey(ctrl_d);
            emul.EmulateKey(x_d);
            emul.EmulateKey(ctrl_u);
            emul.EmulateKey(x_u);
        }

        public void Paste()
        {
            // d - down, u - up
            emul.EmulateKey(ctrl_d);
            emul.EmulateKey(v_d);
            emul.EmulateKey(ctrl_u);
            emul.EmulateKey(v_u);
        }

        public void Process(string changingString)
        {
            changeLang();
            Thread.Sleep(100);
            foreach (var chr in changingString)
            {
                var code = IntPtr.Zero;
                var isSpecial = false;
                parse(chr, ref code, ref isSpecial);

                if (isSpecial)
                    emul.EmulateKey(shift_d);
                var temp = new KeyboardAction() { Msg = 0x0100, WParam = code }; // down key
                emul.EmulateKey(temp);

                temp.Msg = 0x0101; // up key
                emul.EmulateKey(temp);
                
                if (isSpecial)
                    emul.EmulateKey(shift_u);
            }
        }

        private void parse(char key, ref IntPtr code, ref bool isSpecial)
        {
            switch (key)
            {
                case 'a':
                case 'ф': code = VirtualCode.KEY_A; break;
                case 'b':
                case 'и': code = VirtualCode.KEY_B; break;
                case 'c':
                case 'с': code = VirtualCode.KEY_C; break;
                case 'd':
                case 'в': code = VirtualCode.KEY_D; break;
                case 'e':
                case 'у': code = VirtualCode.KEY_E; break;
                case 'f':
                case 'а': code = VirtualCode.KEY_F; break;
                case 'g':
                case 'п': code = VirtualCode.KEY_G; break;
                case 'h':
                case 'р': code = VirtualCode.KEY_H; break;
                case 'i':
                case 'ш': code = VirtualCode.KEY_I; break;
                case 'j':
                case 'о': code = VirtualCode.KEY_J; break;
                case 'k':
                case 'л': code = VirtualCode.KEY_K; break;
                case 'l':
                case 'д': code = VirtualCode.KEY_L; break;
                case 'm':
                case 'ь': code = VirtualCode.KEY_M; break;
                case 'n':
                case 'т': code = VirtualCode.KEY_N; break;
                case 'o':
                case 'щ': code = VirtualCode.KEY_O; break;
                case 'p':
                case 'з': code = VirtualCode.KEY_P; break;
                case 'q':
                case 'й': code = VirtualCode.KEY_Q; break;
                case 'r':
                case 'к': code = VirtualCode.KEY_R; break;
                case 's':
                case 'ы': code = VirtualCode.KEY_S; break;
                case 't':
                case 'е': code = VirtualCode.KEY_T; break;
                case 'u':
                case 'г': code = VirtualCode.KEY_U; break;
                case 'v':
                case 'м': code = VirtualCode.KEY_V; break;
                case 'w':
                case 'ц': code = VirtualCode.KEY_W; break;
                case 'x':
                case 'ч': code = VirtualCode.KEY_X; break;
                case 'y':
                case 'н': code = VirtualCode.KEY_Y; break;
                case 'z':
                case 'я': code = VirtualCode.KEY_Z; break;
                case 'ю': code = VirtualCode.KEY_TOCH; break;

                case '1': code = VirtualCode.KEY_1; break;
                case '2': code = VirtualCode.KEY_2; break;
                case '3': code = VirtualCode.KEY_3; break;
                case '4': code = VirtualCode.KEY_4; break;
                case '5': code = VirtualCode.KEY_5; break;
                case '6': code = VirtualCode.KEY_6; break;
                case '7': code = VirtualCode.KEY_7; break;
                case '8': code = VirtualCode.KEY_8; break;
                case '9': code = VirtualCode.KEY_9; break;
                case '0': code = VirtualCode.KEY_0; break;

                case ',': code = VirtualCode.KEY_ZAP; break;
                case '.': code = VirtualCode.KEY_TOCH; break;
                case '/': code = VirtualCode.KEY_SEP; break;
                case ';': code = VirtualCode.KEY_TOCHZAP; break;
                case '"': code = VirtualCode.KEY_OPOS; break;
                case '[': code = VirtualCode.KEY_LEVKV; break;
                case ']': code = VirtualCode.KEY_PRAVKV; break;
                case ' ': code = VirtualCode.KEY_SPACE; break;

                //ENG-RASKLADKA
                case '!': code = VirtualCode.KEY_1; isSpecial = true; break;
                case '@': code = VirtualCode.KEY_2; isSpecial = true; break;
                case '#': code = VirtualCode.KEY_3; isSpecial = true; break;
                case '$': code = VirtualCode.KEY_4; isSpecial = true; break;
                case '%': code = VirtualCode.KEY_5; isSpecial = true; break;
                case '^': code = VirtualCode.KEY_6; isSpecial = true; break;
                case '&': code = VirtualCode.KEY_7; isSpecial = true; break;
                case '*': code = VirtualCode.KEY_8; isSpecial = true; break;
                case '(': code = VirtualCode.KEY_9; isSpecial = true; break;
                case ')': code = VirtualCode.KEY_0; isSpecial = true; break;
                case '_': code = VirtualCode.KEY_MINUS; isSpecial = true; break;
                case '+': code = VirtualCode.KEY_PLUS; isSpecial = true; break;
                case '|': code = VirtualCode.KEY_VERXSEP; isSpecial = true; break;

                //RU-RASKLADKA
                case '№': code = VirtualCode.KEY_3; isSpecial = true; break;
                case ':': code = VirtualCode.KEY_6; isSpecial = true; break;
                case '?': code = VirtualCode.KEY_7; isSpecial = true; break;
                case '-': code = VirtualCode.KEY_MINUS; isSpecial = true; break;
                case '=': code = VirtualCode.KEY_PLUS; isSpecial = true; break;
                case '\\': code = VirtualCode.KEY_VERXSEP; isSpecial = true; break;
                default: break;
            }
        }
    }
}
