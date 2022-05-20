namespace Ex04.Menus.Interfaces
{
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
        protected int m_UserInput;
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

        public abstract void Show();
    }
}