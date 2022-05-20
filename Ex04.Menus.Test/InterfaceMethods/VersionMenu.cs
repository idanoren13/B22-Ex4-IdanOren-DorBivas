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

        public override void Execute()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}