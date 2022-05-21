namespace Ex04.Menus.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;

    public class MainMenu : SubMenuItem
    {
        private const string k_ExitName = "Exit";

        public MainMenu(string i_Name, Dictionary<int, AbstractMenu> i_SubMenus) : base(i_Name, i_SubMenus)
        {
        }

        public override void AddItem(AbstractMenu i_Item)
        {
            base.AddItem(i_Item);
            if (m_MenuItems.First().Value.Name == k_GoBackName)
            {
                m_MenuItems.First().Value.Name = k_ExitName;
            }
        }
    }
}
