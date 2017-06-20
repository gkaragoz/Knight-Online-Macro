using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOMacro
{
    // Nested Types
    public class InputCatch
    {
        // Methods
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);
    }

    public class SendInputClass
    {
        // Methods
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetMessageExtraInfo();
        public static uint KeyPress(short key)
        {
            INPUT structure = new INPUT
            {
                type = 1,
                ki = {
                    wScan = (short) MapVirtualKey((uint) key, 0),
                    time = 0,
                    dwFlags = 8
                }
            };
            INPUT[] pInputs = new INPUT[] { structure };
            return SendInput(1, pInputs, Marshal.SizeOf(structure));
        }

        public static uint KeyRelease(short key)
        {
            INPUT structure = new INPUT
            {
                type = 1,
                ki = {
                    wScan = (short) MapVirtualKey((uint) key, 0),
                    time = 0,
                    dwFlags = 2
                }
            };
            INPUT[] pInputs = new INPUT[] { structure };
            return SendInput(1, pInputs, Marshal.SizeOf(structure));
        }

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        public static uint RClick()
        {
            INPUT structure = new INPUT
            {
                mi = {
                    dx = 0,
                    dy = 0,
                    mouseData = 0,
                    dwFlags = 8
                }
            };
            INPUT[] pInputs = new INPUT[] { structure };
            return SendInput(1, pInputs, Marshal.SizeOf(structure));
        }

        public static uint RUClick()
        {
            INPUT structure = new INPUT
            {
                mi = {
                    dx = 0,
                    dy = 0,
                    mouseData = 0,
                    dwFlags = 0x10
                }
            };
            INPUT[] pInputs = new INPUT[] { structure };
            return SendInput(1, pInputs, Marshal.SizeOf(structure));
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            // Fields
            [FieldOffset(4)]
            public SendInputClass.HARDWAREINPUT hi;
            [FieldOffset(4)]
            public SendInputClass.KEYBDINPUT ki;
            [FieldOffset(4)]
            public SendInputClass.MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }

        private enum InputType
        {
            INPUT_MOUSE,
            INPUT_KEYBOARD,
            INPUT_HARDWARE
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [Flags]
        private enum KEYEVENTF
        {
            EXTENDEDKEY = 1,
            KEYUP = 2,
            SCANCODE = 8,
            UNICODE = 4
        }

        [Flags]
        private enum MOUSEEVENTF
        {
            ABSOLUTE = 0x8000,
            LEFTDOWN = 2,
            LEFTUP = 4,
            MIDDLEDOWN = 0x20,
            MIDDLEUP = 0x40,
            MOVE = 1,
            RIGHTDOWN = 8,
            RIGHTUP = 0x10,
            VIRTUALDESK = 0x4000,
            WHEEL = 0x800,
            XDOWN = 0x80,
            XUP = 0x100
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
    }

}
