using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class DateTimeMenu : MenuItem, IMenuObserver
    {

        private eUserOptions m_UserInput;
        private StringBuilder m_StringBuilder;
        //private static readonly string[] r_DateTimeMessages = { "Show Date/Time " , $"0 - Back{Environment.NewLine}", "Please select option:" };

        private const string k_HeadLine = "Show Date/Time ";
        private const string k_ExitMessage = "0 - Back\n";
        private const string k_SelectMessage = "Please select option:";

        private readonly List<string> r_DateTimeMenuMessages = new List<string>();

        public DateTimeMenu()
        {
            m_StringBuilder = new StringBuilder();
            initiateMenu();
        }

        private void initiateMenu()
        {
            int menuIndex = 1;

            r_DateTimeMenuMessages.Add("Show Date");
            r_DateTimeMenuMessages.Add("Show Time");
            m_StringBuilder.AppendLine(k_HeadLine);
            foreach (string message in r_DateTimeMenuMessages)
            {
                m_StringBuilder.Append($"{menuIndex} - ");
                m_StringBuilder.AppendLine(message);
                menuIndex++;
            }

            m_StringBuilder.AppendLine(k_ExitMessage);
            m_StringBuilder.AppendLine(k_SelectMessage);
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
            Console.Write(m_StringBuilder.ToString());
            checkInput(Console.ReadLine());
            Console.Clear();
        }

        private void checkInput(string  i_UserInput)
        {
            int tryUserInput = int.Parse(i_UserInput);

            if (tryUserInput < 0 || tryUserInput > r_MenuItems.Count)
            {
                throw new ArgumentOutOfRangeException("inserted value out of range\n");
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
