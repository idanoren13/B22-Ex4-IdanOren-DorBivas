namespace Ex04.Menus.Test.InterfaceMethods
{
    using System;
    using Ex04.Menus.Interfaces;

    public class DateMenu : FinalMenuItem
    {
        public DateMenu(string i_Name, SubMenuItem io_Base) : base(i_Name, io_Base)
        {
        }

        public override void Execute()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.ToString("dd/MM/yyyy"));
        }
    }
}