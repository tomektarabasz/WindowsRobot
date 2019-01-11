using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellow");

            Robot robot = new Robot();
            robot.calculator();

            Console.ReadKey();
        }
    }
}
