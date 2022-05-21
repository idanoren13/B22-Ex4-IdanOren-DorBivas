using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        private const string k_ExitName = "Exit";

        public MainMenu(string i_Name, Dictionary<int, MenuItem> i_SubMenus) : base(i_Name, i_SubMenus)
        {
        }

        public override void AddItem(MenuItem i_Item)
        {
            base.AddItem(i_Item);
            if (m_SubMenuDict.First().Value.Name == k_GoBackName)
            {
                m_SubMenuDict.First().Value.Name = k_ExitName;
            }
        }
    }
}
