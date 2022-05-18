using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuObserver
    {
        void Show();
    }

    public class MenuItem
    {
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

        public void AttachObserver(IMenuObserver i_MenuItemObserver)
        {
            r_MenuObservers.Add(i_MenuItemObserver);
        }

        public void DetachObserver(IMenuObserver i_MenuItemObserver)
        {
            r_MenuObservers.Remove(i_MenuItemObserver);
        }


    }
}