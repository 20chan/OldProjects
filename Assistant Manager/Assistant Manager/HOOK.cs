using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Assistant_Manager
{
    public struct TimeKey
    {
        public Keys Key;
        public KeyEventType EventType;
        public IMEMODE IME;
        public DateTime Time;
    }
    public class HOOK
    {
        public static List<TimeKey> PressedKeys = new List<TimeKey>();

        public HOOK()
        {
            SetHook();
        }
        ~HOOK()
        {
            UnHook();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("User32.dll")]
        private static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;
        private const int WM_KEYUP = 0x101;

        private LowLevelKeyboardProc _proc = hookProc;

        private static IntPtr hhook = IntPtr.Zero;

        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }

        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                TimeKey t = new TimeKey();
                t.Key = (Keys)vkCode; t.Time = DateTime.Now;
                t.EventType = KeyEventType.KEYDOWN;
                t.IME = isIMEKorean(Main_Form.mainForm.Handle) ? IMEMODE.KOREAN : IMEMODE.ENGLISH;

                PressedKeys.Add(t);
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
            }
            else if (code >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                TimeKey t = new TimeKey();
                t.Key = (Keys)vkCode; t.Time = DateTime.Now;
                t.EventType = KeyEventType.KEYUP;
                t.IME = isIMEKorean(Main_Form.mainForm.Handle) ? IMEMODE.KOREAN : IMEMODE.ENGLISH;

                PressedKeys.Add(t);
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
            }
            else return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

        public static void MakeKeyEvent(Keys k, KeyEventType keyEvent)
        {
            switch (keyEvent)
            {
                case KeyEventType.KEYDOWN:
                    keybd_event((byte)k, 0x00, 0x00, 0);
                    break;
                case KeyEventType.KEYUP:
                    keybd_event((byte)k, 0x00, 0x02, 0);
                    break;
                case KeyEventType.CLICK:
                    keybd_event((byte)k, 0x00, 0x00, 0);
                    keybd_event((byte)k, 0x00, 0x02, 0);
                    break;
            }
        }

        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr hImc, out int lpConversion, out int lpSentence);

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        public static bool isIMEKorean(IntPtr hWnd)
        {
            IntPtr _hImc = ImmGetContext(hWnd);
            int lpConversion;
            int lpSentence;
            ImmGetConversionStatus(_hImc, out lpConversion, out lpSentence);
            return lpConversion == 0 ? false : true;
        }
    }
    public enum KeyEventType
    {
        KEYDOWN, KEYUP, CLICK
    }

    public enum IMEMODE
    {
        KOREAN, ENGLISH
    }
}
