using System;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class VersionMenu : AbstractMenu
    {
        public override void Show()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}