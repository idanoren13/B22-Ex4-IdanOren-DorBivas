using System;

namespace Ex04.Menus.Interfaces
{
    public class DateMenu : AbstractMenu, IMenu
    {
        public override void Show()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.ToString("dd/MM/yyyy"));
        }
    }
}

