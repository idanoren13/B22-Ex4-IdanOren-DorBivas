using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_Name, List<MenuItem> i_SubMenus) : base(i_Name, i_SubMenus)
        {
        }

        public override void AddItem(MenuItem i_Item, string i_GoBackText = "exit")
        {
            base.AddItem(i_Item, i_GoBackText);
        }
    }
}
