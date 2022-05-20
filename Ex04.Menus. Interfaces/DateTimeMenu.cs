namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;

    class DateTimeMenu : AbstractMenu
    {
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
            buildMenuBody(r_DateTimeMenuMessages, k_MenuHeadLine, k_backMessage);
        }
    }
}

