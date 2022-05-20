using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IMenu
    {
        void Show();
    }

    public abstract class AbstractMenu : IMenu
    {
        protected enum eUserOptions { Zero, One, Two }
        protected eUserOptions m_UserInput;
        protected readonly List<AbstractMenu> r_MenuItems = new List<AbstractMenu>();
        protected readonly StringBuilder r_MenuBuffer = new StringBuilder();
        private const string k_SelectMessage = "Please select an option:";

        public List<AbstractMenu> MenuItems
        {
            get => r_MenuItems;
        }

        protected virtual void buildMenuBody(List<string> i_MenuMessages, string i_MenuHeadLine, string i_BackMessage)
        {
            int menuIndex = 1;
            r_MenuBuffer.AppendLine(i_MenuHeadLine);
            foreach (string message in i_MenuMessages)
            {
                r_MenuBuffer.Append($"{menuIndex} - ");
                r_MenuBuffer.AppendLine(message);
                menuIndex++;
            }

            r_MenuBuffer.AppendLine(i_BackMessage);
            r_MenuBuffer.AppendLine(k_SelectMessage);
        }

        public virtual void Show()
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

        protected virtual void consoleWrapper()
        {
            Console.Write(r_MenuBuffer.ToString());
            checkInput(Console.ReadLine());
            Console.Clear();
        }

        protected virtual void checkInput(string i_UserInput)
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

        protected virtual void executeAction()
        {
            switch (m_UserInput)
            {
                case eUserOptions.Zero:
                    break;
                case eUserOptions.One:
                    r_MenuItems[(int)m_UserInput - 1].Show();
                    break;
                case eUserOptions.Two:
                    r_MenuItems[(int)m_UserInput - 1].Show();
                    break;
                default:
                    break;
            }
        }
    }
}