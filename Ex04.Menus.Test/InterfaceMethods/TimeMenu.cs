namespace Ex04.Menus.Test.InterfaceMethods
{
    using System;
    using System.Collections.Generic;
    using Ex04.Menus.Interfaces;

    public class TimeMenu : FinalMenuItem
    {
        public TimeMenu(string i_Name, SubMenuItem io_Base) : base(i_Name, io_Base)
        {
        }

        public override void Act()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("HH:mm:ss"));
        }
    }
}