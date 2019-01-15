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
using System.Threading;

namespace WindowsRobot
{
    class Robot
    {
        public void calculator()
        {
            InputSimulator inputSimulator = new InputSimulator();
            WindowsInput.KeyboardSimulator keyboard = new KeyboardSimulator(inputSimulator);
            WindowsInput.MouseSimulator mouseSimulator = new MouseSimulator(inputSimulator);

            string nazwaProcesu = "Mk";
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

            
            Thread.Sleep(140);

            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.F2);//utworz nowy
            Thread.Sleep(2000);           
            waitAfterPressKey(keyboard.TextEntry,"123");//Usun konstrahenta o tym NIP
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.F8);//Usuniecie NIP
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.VK_Y);
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.VK_Y);//Zamkniecie komunikatow
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.DOWN);
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.F2);//Stworzenie nowego kontrahenta
            waitAfterPressKey(keyboard.TextEntry,"Nazwa skrocona");
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.TAB);
            waitAfterPressKey(keyboard.KeyPress,VirtualKeyCode.VK_P);
            waitAfterPressKey(keyboard.KeyPress, VirtualKeyCode.TAB);
            waitAfterPressKey(keyboard.TextEntry, "7740001454");
            waitAfterPressKey(keyboard.KeyPress, VirtualKeyCode.F2);
            waitAfterPressKey(keyboard.KeyPress, VirtualKeyCode.VK_Y);
            waitAfterPressKey(keyboard.KeyPress, VirtualKeyCode.RETURN);
            waitAfterPressKey(keyboard.TextEntry, "7740001454");
            waitAfterPressKey(keyboard.KeyPress, VirtualKeyCode.TAB);
            //koniec dodawania kontrahenta
            waitAfterPressKey(keyboard.TextEntry, "7");
            waitAfterPressKey(keyboard.KeyPress, VirtualKeyCode.RETURN);

            
            // Poczatek programu
            //keyboard.KeyPress(VirtualKeyCode.F2);
            //Thread.Sleep(czas);

            ////Tworzenie kontrahenta
            //keyboard.TextEntry("123");
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.F8);
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.VK_Y);
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.VK_Y); 
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.DOWN);
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.F2);
            //Thread.Sleep(czas);
            //keyboard.TextEntry("NazwaSkrocona");
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.TAB);
            //Thread.Sleep(czas);
            //keyboard.TextEntry("P");
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.TAB);
            //Thread.Sleep(czas);
            //keyboard.TextEntry("1234567890");
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.F2);
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.VK_Y);
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.RETURN);
            ////koniec dodawania kontrahenta

            //keyboard.KeyPress(VirtualKeyCode.TAB);
            //Thread.Sleep(czas);
            //keyboard.TextEntry("7");
            //Thread.Sleep(czas);
            //keyboard.KeyPress(VirtualKeyCode.RETURN);







            //keyboard.KeyPress(VirtualKeyCode.TAB);

            //keyboard.TextEntry("345");

            //keyboard.KeyPress(VirtualKeyCode.TAB);

            //keyboard.TextEntry("678");

            //keyboard.KeyPress(VirtualKeyCode.F2);
            ////
            string nazwaOkna = process.MainWindowTitle;
            

        }
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public const int czas = 1500;
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
        public static void waitAfterPressKey(Func<VirtualKeyCode,IKeyboardSimulator> func,VirtualKeyCode virtualKeyCode)
        {
            Thread.Sleep(czas);
            func(virtualKeyCode);
        }
        public static void waitAfterPressKey(Func<string, IKeyboardSimulator> func, string str)
        {
            Thread.Sleep(czas);
            func(str);
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
