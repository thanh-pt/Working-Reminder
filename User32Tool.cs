using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Working_Reminder
{
    public class User32Tool
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public const uint FLASHW_STOP = 0;
        public const uint FLASHW_CAPTION = 1;
        public const uint FLASHW_TRAY = 2;
        public const uint FLASHW_ALL = 3;
        public const uint FLASHW_TIMER = 4;
        public const uint FLASHW_TIMERNOFG = 12;

        public static bool flashed = false;

        public static void Flash(Form form)
        {
            if (flashed == false)
            {
                FLASHWINFO fw = new FLASHWINFO();

                fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(fw));
                fw.hwnd = form.Handle;
                fw.dwFlags = FLASHW_ALL;
                fw.uCount = uint.MaxValue; // Flash indefinitely
                fw.dwTimeout = 0;

                FlashWindowEx(ref fw);
            }
            flashed = true;
        }

        public static void StopFlash(Form form)
        {
            FLASHWINFO fw = new FLASHWINFO();

            fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(fw));
            fw.hwnd = form.Handle;
            fw.dwFlags = FLASHW_STOP;
            fw.uCount = uint.MaxValue;
            fw.dwTimeout = 0;

            FlashWindowEx(ref fw);
            flashed = false;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static string GetActiveWindowProcess()
        {
            IntPtr handle = GetForegroundWindow();
            uint processId;
            GetWindowThreadProcessId(handle, out processId);
            Process proc = Process.GetProcessById((int)processId);
            return proc.ProcessName;
        }
    }

}
