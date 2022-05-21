namespace Ex04.Menus.Test.InterfaceMethods
{
    using System;
    using System.Collections.Generic;
    using Ex04.Menus.Interfaces;

    public class VersionMenu : FinalMenuItem
    {
        public VersionMenu(string i_Name, SubMenuItem io_Base) : base(i_Name, io_Base)
        {
        }

        public override void Act()
        {
            Console.WriteLine("Version: 22.2.4.8950");
        }
    }
}