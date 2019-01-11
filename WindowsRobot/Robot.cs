using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using WindowsInput;
using System.Windows.Input;
using Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using WindowsInput.Native;

namespace WindowsRobot
{
    class Robot
    {
        public void calculator()
        {
            InputSimulator inputSimulator = new InputSimulator();
            WindowsInput.KeyboardSimulator keyboard = new KeyboardSimulator(inputSimulator);
            WindowsInput.MouseSimulator mouseSimulator = new MouseSimulator(inputSimulator);

            string nazwaProcesu = "Calculator";
            Process process = Process.GetProcessesByName(nazwaProcesu).FirstOrDefault();
            IntPtr handle = process.MainWindowHandle;
            
            WindowHelper.BringProcessToFront(process);
            
            //SetForegroundWindow(handle);
            //var i = User32.IsIconic(handle);
            
            Console.WriteLine(process.MainWindowTitle);
            Console.WriteLine(process.ProcessName);

            //User32.ShowWindow(handle, 9);
            bringToFront(nazwaProcesu);
            SetForegroundWindow(handle);
            User32.SetActiveWindow(handle);
            keyboard.TextEntry("123");
                       
            keyboard.KeyPress(VirtualKeyCode.TAB);
            string nazwaOkna = process.MainWindowTitle;
            

        }
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void bringToFront(string title)
        {
            // Get a handle to the Calculator application.
            IntPtr handle = FindWindow(null, title);

            // Verify that Calculator is a running process.
            if (handle == IntPtr.Zero)
            {
                return;
            }

            // Make Calculator the foreground application
            SetForegroundWindow(handle);
        }
    }
    public static class WindowHelper
    {
        public static void BringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }

        const int SW_RESTORE = 9;

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
    }







}
