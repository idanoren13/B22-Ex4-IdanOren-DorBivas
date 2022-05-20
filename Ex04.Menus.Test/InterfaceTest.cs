namespace Ex04.Menus.Test
{
    using Ex04.Menus.Interfaces;
    using System;
    using System.Collections.Generic;

    class InterfaceTest
    {
        private readonly MainMenu r_MainMenu;
        private readonly List<AbstractMenu> r_MenuItems;

        public InterfaceTest()
        {
            r_MainMenu = new MainMenu();
            r_MenuItems = new List<AbstractMenu>();
            attachMenus();
        }

        private void attachMenus()
        {
            AbstractMenu version = new VersionMenu();
            AbstractMenu spaces = new SpacesMenu();
            AbstractMenu time = new TimeMenu();
            AbstractMenu date = new DateMenu();
            r_MenuItems.Add(version);
            r_MenuItems.Add(spaces);
            r_MenuItems.Add(time);
            r_MenuItems.Add(date);
            r_MainMenu.MenuItems[0].MenuItems.Add(spaces);
            r_MainMenu.MenuItems[0].MenuItems.Add(version);
            r_MainMenu.MenuItems[1].MenuItems.Add(date);
            r_MainMenu.MenuItems[1].MenuItems.Add(time);
        }

        public void Run()
        {
            r_MainMenu.Show();
        }
    }
}