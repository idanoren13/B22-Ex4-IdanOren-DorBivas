using System;

namespace Ex04.Menus.Interfaces
{
    public class TimeMenu : AbstractMenu
    {
        public override void Show()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("HH:mm:ss"));
        }
    }
}