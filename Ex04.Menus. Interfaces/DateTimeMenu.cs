namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;

    class DateTimeMenu : AbstractMenu, IMenuObserver
    {
        private eUserOptions m_UserInput;
        private readonly List<string> r_DateTimeMenuMessages ;
        private const string k_MenuHeadLine = "Show Date/Time";
        private const string k_backMessage = "0 - Back\n";

        public DateTimeMenu()
        {
            r_DateTimeMenuMessages = new List<string>();
            initiateMenu();
        }

        private void initiateMenu()
        {
            r_DateTimeMenuMessages.Add("Show Date");
            r_DateTimeMenuMessages.Add("Show Time");
            displayMenuBody(r_DateTimeMenuMessages, k_MenuHeadLine, k_backMessage);
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
}
