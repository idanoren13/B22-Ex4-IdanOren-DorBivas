using System;
using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class ConsoleHandler
    {
        private readonly MainMenu m_MainMenu;

        public ConsoleHandler()
        {
            m_MainMenu = new MainMenu("Main delegates", new Dictionary<int, MenuItem>());
            MenuItem countSpacesAndShowVersion = new MenuItem("Version and Spaces", new Dictionary<int, MenuItem>(), m_MainMenu);
            countSpacesAndShowVersion.Chosen += countSpacesAndShowVersion.goFowradRequest_Chosen;
            MenuItem showTimeAndShowDate = new MenuItem("Shows Time/Date", new Dictionary<int, MenuItem>(), m_MainMenu);
            showTimeAndShowDate.Chosen += showTimeAndShowDate.goFowradRequest_Chosen;
            addSpacesAndShowVersion(countSpacesAndShowVersion);
            addShowTimeAndShowDate(showTimeAndShowDate);
        }

        public void Run()
        {
            m_MainMenu.Show();
        }

        private void addShowTimeAndShowDate(MenuItem i_ShowTimeAndShowDate)
        {
            MenuItem showDate = new MenuItem("Show date", null, i_ShowTimeAndShowDate);
            showDate.Chosen += ShowDate_Chosen;
            MenuItem showTime = new MenuItem("Show Time", null, i_ShowTimeAndShowDate);
            showTime.Chosen += TimeRequest_Chosen;
        }

        private void addSpacesAndShowVersion(MenuItem countSpacesAndShowVersion)
        {
            MenuItem countSpaces = new MenuItem("Count spaces", null, countSpacesAndShowVersion);
            countSpaces.Chosen += CountSpaces_Chosen;
            MenuItem showVersion = new MenuItem("Show Version", null, countSpacesAndShowVersion);
            showVersion.Chosen += ShowVersion_Chosen;
        }

        public void ShowVersion_Chosen(MenuItem i_Invoker)
        {
            Console.WriteLine("Version: 21.1.4.8930");
        }

        public void CountSpaces_Chosen(MenuItem i_Invoker)
        {
            int numberOfSpaces = 0;
            string userInput;

            Console.WriteLine("Please enter a sentence: ");
            userInput = Console.ReadLine();
            foreach (char character in userInput)
            {
                if (char.IsWhiteSpace(character))
                {
                    numberOfSpaces++;
                }
            }

            Console.WriteLine("The number of spaces in the sentence is: {0}", numberOfSpaces);
        }

        public void ShowDate_Chosen(MenuItem i_Invoker)
        {
            Console.WriteLine(DateTime.Today.ToString("dd/MM/yyyy"));
        }

        public void TimeRequest_Chosen(MenuItem i_Invoker)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
