using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuObserver
    {
        void Show();
    }

    public abstract class MenuItem
    {
        protected enum eUserOptions {Zero, One, Two}
        public readonly List<IMenuObserver> r_MenuObservers = new List<IMenuObserver>(); // todo ?
        protected readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        protected readonly StringBuilder r_MenuBuffer = new StringBuilder();

        private const string k_SelectMessage = "Please select an option:";

        List<IMenuObserver> MenuObservers
        {
            get=> r_MenuObservers;
        }

        public List<MenuItem> MenuItems
        {
            get => r_MenuItems;
        }

        protected void displayMenuBody(List<string> i_MenuMessages, string i_MenuHeadLine, string i_BackMessage)
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

        protected void AddObserver(IMenuObserver i_MenuObserver)
        {
            r_MenuObservers.Add(i_MenuObserver);
        }

        protected void RemoveObserver(IMenuObserver i_MenuObserver)
        {
            r_MenuObservers.Remove(i_MenuObserver);
        }
    }
}