using System;
using System.Runtime.InteropServices;


namespace GPA_Calculator
{
    internal class WinAPI
    {
        public const int HOR_Positive = 0X1;

        public const int HOR_NEGATIVE = 0X2;

        public const int VER_POSITIVE = 0X4;

        public const int VER_NEGATIVE = 0X8;

        public const int CENTER = 0X10;

        public const int BLEND = 0X80000;

        public const int AW_ACTIVATE = 0X20000;

        public const int AW_SLIDE = 0X40000;

        public const int AW_HIDE = 0x00010000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int AnimateWindow(IntPtr hwand, int dwTime, int dwFlag);
    }
}
