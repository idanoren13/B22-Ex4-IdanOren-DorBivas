// $G$ DSN-999 (-10) The specific operation method shouldn't be part of the Menu project.
namespace Ex04.Menus.Interfaces
{
    using System.Collections.Generic;

    public class MainMenu : AbstractMenu
    {
        private readonly List<string> m_MainMenuMessages;
        private const string k_MenuHeadLine = "Main menu Interface:";
        private const string k_BackMessage = "0 - Exit\n";

        public MainMenu()
        {
            m_MainMenuMessages = new List<string>();
            initiateSubMenus();
            buildMainMenu();
        }

        private void initiateSubMenus()
        {
            VersionSpacesMenu versionAndSpacesMenu = new VersionSpacesMenu();
            r_MenuItems.Add(versionAndSpacesMenu);
            DateTimeMenu dateAndTimeMenu = new DateTimeMenu();
            r_MenuItems.Add(dateAndTimeMenu);
        }

        private void buildMainMenu()
        {
            m_MainMenuMessages.Add("Version and Spaces");
            m_MainMenuMessages.Add("Show Date/Time");
            buildMenuBody(m_MainMenuMessages, k_MenuHeadLine, k_BackMessage);
        }
    }
}
