using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class VersionSpacesMenu : AbstractMenu
    {
        private readonly List<string> r_VersionSpacesMenuMessages;
        private const string k_MenuHeadLine = "Version and spaces menu";
        private const string k_BackMessage = "0 - Back\n"; // todo 

        public VersionSpacesMenu()
        {
            r_VersionSpacesMenuMessages = new List<string>();
            initiateMenu();
        }

        private void initiateMenu()
        {
            r_VersionSpacesMenuMessages.Add("Count the amount of Spaces");
            r_VersionSpacesMenuMessages.Add("Display version");
            buildMenuBody(r_VersionSpacesMenuMessages, k_MenuHeadLine, k_BackMessage);
        }
    }
}

