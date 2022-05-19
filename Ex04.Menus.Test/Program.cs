using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Delegates implemented menu");
            ConsoleHandler consoleManage = new ConsoleHandler();
            consoleManage.Run();
        }
    }
}
