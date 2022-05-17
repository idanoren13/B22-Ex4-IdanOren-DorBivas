using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_Name, List<MenuItem> i_SubMenus) : base(i_Name, i_SubMenus, null)
        {
        }
    }
}
