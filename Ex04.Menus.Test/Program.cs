using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Delegates implemented menu");
            ConsoleHandler consoleManage = new ConsoleHandler();
            consoleManage.Run();

            Console.WriteLine("Interface implemented menu");
            InterfaceTest interfaceTest = new InterfaceTest();
            interfaceTest.Run();
        }
    }
}
