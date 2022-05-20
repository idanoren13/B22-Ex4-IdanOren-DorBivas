using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class VersionSpacesMenu : MenuItem, IMenuObserver
    {
        private eUserOptions m_UserInput;
        private readonly List<string> r_VersionSpacesMenuMessages;
        private const string k_MenuHeadLine = "Version and spaces menu";
        private const string k_BackMessage = "0 - Back\n"; // todo ?

        public VersionSpacesMenu()
        {
            r_VersionSpacesMenuMessages = new List<string>();
            initiateMenu();
        }

        private void initiateMenu()
        {
            r_VersionSpacesMenuMessages.Add("Count the amount of Spaces");
            r_VersionSpacesMenuMessages.Add("Display version");
            displayMenuBody(r_VersionSpacesMenuMessages, k_MenuHeadLine, k_BackMessage);
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
            bool isNumeric = int.TryParse(i_UserInput, out tryUserInput);

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

