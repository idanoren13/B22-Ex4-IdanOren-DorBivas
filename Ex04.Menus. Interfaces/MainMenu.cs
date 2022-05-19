//using System;
//using System.Collections.Generic;
//using System.Text;

//// $G$ DSN-999 (-10) The specific operation method shouldn't be part of the Menu project.

//namespace Ex04.Menus.Interfaces
//{
//    public class MainMenu
//    {
//        private string m_Input;
//        private readonly StringBuilder r_StringBuilder = new StringBuilder();
//        private readonly List<string> m_MainMenuMessages = new List<string>();
//        private const string k_HeadLine = "Main Delegates (Interface)";
//        private readonly string r_ExitMessage = $"0 - Exit{Environment.NewLine}";
//        private const string k_SelectMessage = "Please select option:";
//        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

//        public List<MenuItem> MenuItems
//        {
//            get => r_MenuItems;
//        }

//        public MainMenu()
//        {
//            m_Input = null;
//            VersionAndSpacesMenu versionAndSpacesMenu = new VersionAndSpacesMenu();
//            r_MenuItems.Add(versionAndSpacesMenu);

//            DateAndTimeMenu dateAndTimeMenu = new DateAndTimeMenu();
//            r_MenuItems.Add(dateAndTimeMenu);

//            buildMainMenuOutput();
//        }

//        private void buildMainMenuOutput()
//        {
//            m_MainMenuMessages.Add("Version and Spaces");
//            m_MainMenuMessages.Add("Show Date/Time");
//            int index = 1;
//            r_StringBuilder.Append(k_HeadLine);
//            r_StringBuilder.Append("\n");
//            foreach (string message in m_MainMenuMessages)
//            {
//                r_StringBuilder.Append(index);
//                r_StringBuilder.Append(" - ");
//                r_StringBuilder.Append(message);
//                r_StringBuilder.Append("\n");
//                index++;
//            }
//            r_StringBuilder.Append(r_ExitMessage);
//            r_StringBuilder.Append("\n");
//            r_StringBuilder.Append(k_SelectMessage);
//            r_StringBuilder.Append("\n");
//        }

//        public void Show()
//        {
//            while (m_Input != "0")
//            {
//                try
//                {
//                    Console.Write(r_StringBuilder.ToString());
//                    m_Input = Console.ReadLine();
//                    checkInput();
//                    takeAction();
//                }
//                catch (Exception e)
//                {
//                    Console.Clear();
//                    Console.WriteLine(e.Message);
//                }
//            }
//        }

//        private void checkInput()
//        {
//            int input = int.Parse(m_Input);
//            if (input < 0 || input > r_MenuItems.Count)
//            {
//                throw new Exception("inserted value out of range\n");
//            }
//        }

//        private void takeAction()
//        {
//            switch (m_Input)
//            {
//                case "1":
//                    {
//                        MenuItems[int.Parse(m_Input) - 1].Show();
//                        break;
//                    }
//                case "2":
//                    {
//                        MenuItems[int.Parse(m_Input) - 1].Show();
//                        break;
//                    }
//                case "0":
//                    {
//                        Console.Clear();
//                        break;
//                    }
//            }
//        }
//    }
//}