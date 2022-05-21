namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IMenu
    {
        void Show();
    }

    public abstract class AbstractMenu : IMenu
    {
        public enum eItemType
        {
            Action,
            Menu
        }

        protected const string k_GoBackName = "Go Back";
        protected int m_LevelInMenu;
        protected bool m_continueShowLoop = true;
        protected string m_Name;
        protected AbstractMenu m_Base;
        protected eItemType m_ItemType = eItemType.Action;
        protected Dictionary<int, AbstractMenu> m_MenuItems;

        public Dictionary<int, AbstractMenu> MenuItems
        {
            get => m_MenuItems;
        }

        public int Level
        {
            get => m_LevelInMenu;
            set => m_LevelInMenu = value;
        }

        public eItemType ItemType
        {
            get => m_ItemType;
        }

        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }

        public bool ContinueShowLoop
        {
            set => m_continueShowLoop = value;
        }

        protected virtual void initiateMenuDetails(string i_Name, Dictionary<int, AbstractMenu> i_SubMenus)
        {
            m_Name = i_Name;
            m_MenuItems = i_SubMenus;
            m_LevelInMenu = 1;
            if (i_SubMenus != null)
            {
                m_ItemType = i_SubMenus.Count == 0 ? eItemType.Action : eItemType.Menu;
            }
        }

        public virtual void Show()
        {
            uint parsedChoice;
            bool isValid;

            while (m_continueShowLoop)
            {
                Console.WriteLine(this.ToString());
                isValid = uint.TryParse(Console.ReadLine(), out parsedChoice);
                while (!isValid || parsedChoice >= m_MenuItems.Count)
                {
                    Console.WriteLine($"ivalid input please enter number between 0 to {m_MenuItems.Count - 1}");
                    isValid = uint.TryParse(Console.ReadLine(), out parsedChoice);
                }

                Console.Clear();
                m_MenuItems[(int)parsedChoice].Show();
            }
        }
    }
}

