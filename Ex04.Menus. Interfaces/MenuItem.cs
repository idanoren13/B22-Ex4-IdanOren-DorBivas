using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuObserver
    {
        void Show();
    }

    public abstract class MenuItem
    {
        protected enum eUserOptions {Zero, One, Two}
        public readonly List<IMenuObserver> r_MenuObservers = new List<IMenuObserver>();
        protected readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        List<IMenuObserver> MenuObservers
        {
            get=> r_MenuObservers;
        }

        public List<MenuItem> MenuItems
        {
            get => r_MenuItems;
        }

        public void AddObserver(IMenuObserver i_MenuObserver)
        {
            r_MenuObservers.Add(i_MenuObserver);
        }

        public void RemoveObserver(IMenuObserver i_MenuObserver)
        {
            r_MenuObservers.Remove(i_MenuObserver);
        }
    }
}