using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class ConsoleHandler
    {
        private MainMenu m_MainMenu;

        IEngine Iengine = new EngineLogic();

        //this needs to be informed
        public ConsoleHandler()
        {
            m_MainMenu = new MainMenu("Main delegates", new List<MenuItem>());
            //One of the sub lists

            // $G$ SFN-003 (-7) The progammer that uses the menu component should not be enforced to specify a parent menu when he wants to add a submenu.
            //MenuItem exit = new MenuItem("Exit", null, 1, Iengine, m_MainMenu);
            //exit.Chosen += Iengine.ExitProgram_Chosen;

            MenuItem countSpacesAndShowVersion = new MenuItem("Version and Spaces", new List<MenuItem>(), m_MainMenu);
            countSpacesAndShowVersion.Chosen += Iengine.GoForth_Chosen;

            MenuItem showTimeAndShowDate = new MenuItem("Shows Time/Date", new List<MenuItem>(), m_MainMenu);
            showTimeAndShowDate.Chosen += Iengine.GoForth_Chosen;

            addSpacesAndShowVersion(countSpacesAndShowVersion);
            addShowTimeAndShowDate(showTimeAndShowDate);

            m_MainMenu.AddItem(exit);
            m_MainMenu.AddItem(countSpacesAndShowVersion);
            m_MainMenu.AddItem(showTimeAndShowDate);
        }
        public void Run()
        {
            m_MainMenu.Show();
        }
        private void addShowTimeAndShowDate(MenuItem i_ShowTimeAndShowDate)
        {
            // $G$ SFN-004 (-7) The menu items containing the exit / back option should be created by the menu itself, not by the user.
            MenuItem goBack = new MenuItem("Back", null, 3, Iengine, i_ShowTimeAndShowDate);
            goBack.Chosen += Iengine.BackRequest_Chosen;

            MenuItem showDate = new MenuItem("Show date", null, 3, Iengine, i_ShowTimeAndShowDate);
            showDate.Chosen += Iengine.ShowDate_Chosen;

            MenuItem showTime = new MenuItem("Show Time", null, 3, Iengine, i_ShowTimeAndShowDate);
            showTime.Chosen += Iengine.TimeRequest_Chosen;

            i_ShowTimeAndShowDate.AddItem(goBack);
            i_ShowTimeAndShowDate.AddItem(showDate);
            i_ShowTimeAndShowDate.AddItem(showTime);
        }

        private void addSpacesAndShowVersion(MenuItem countSpacesAndShowVersion)
        {
            MenuItem goBack = new MenuItem("Back", null, 3, Iengine, countSpacesAndShowVersion);
            goBack.Chosen += Iengine.BackRequest_Chosen;

            MenuItem countSpaces = new MenuItem("Count spaces", null, 3, Iengine, countSpacesAndShowVersion);
            countSpaces.Chosen += Iengine.CountSpaces_Chosen;

            MenuItem showVersion = new MenuItem("Show Version", null, 3, Iengine, countSpacesAndShowVersion);
            showVersion.Chosen += Iengine.ShowVersion_Chosen;

            countSpacesAndShowVersion.AddItem(goBack);
            countSpacesAndShowVersion.AddItem(countSpaces);
            countSpacesAndShowVersion.AddItem(showVersion);

        }
    }
}
