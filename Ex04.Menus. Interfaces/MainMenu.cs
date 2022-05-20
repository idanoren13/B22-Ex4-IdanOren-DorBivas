// $G$ DSN-999 (-10) The specific operation method shouldn't be part of the Menu project.
namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;

    public class MainMenu : AbstractMenu
    {
        private eUserOptions m_UserInput;
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
            displayMenuBody(m_MainMenuMessages, k_MenuHeadLine, k_BackMessage);
        }

        public void Show()
        {
            do
            {
                try
                {
                    consoleWrapper();
                    executeAction();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }

            } while (m_UserInput != eUserOptions.Zero);
        }

        private void consoleWrapper()
        {
            Console.Write(r_MenuBuffer.ToString());
            checkInput(Console.ReadLine());
            Console.Clear();
        }

        private void checkInput(string i_UserInput)
        {
            int tryUserInput;
            bool isNumeric = int.TryParse(i_UserInput,out tryUserInput);

            if (!isNumeric)
            {
                throw new FormatException($"non format input!{Environment.NewLine}");
            }

            if (tryUserInput < 0 || tryUserInput > r_MenuItems.Count)
            {
                throw new ArgumentOutOfRangeException($"inserted value out of range{Environment.NewLine}");
            }

            m_UserInput = (eUserOptions)tryUserInput;
        }

        private void executeAction()
        {
            switch (m_UserInput)
            {
                case eUserOptions.Zero:
                    break;
                case eUserOptions.One:
                    MenuItems[(int)m_UserInput - 1].Show();
                    break;
                case eUserOptions.Two:
                    MenuItems[(int)m_UserInput - 1].Show();
                    break;
                default:
                    break;
            }
        }
    }
}
}