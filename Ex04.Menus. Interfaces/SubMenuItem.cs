namespace Ex04.Menus.Interfaces
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class SubMenuItem : AbstractMenu
    {
        private class GoBackMenuItem : SubMenuItem
        {
            public GoBackMenuItem() : base(k_GoBackName, null)
            {
            }

            public override void Show()
            {
                m_Base.ContinueShowLoop = false;
            }
        }

        protected SubMenuItem(string i_Name, Dictionary<int, AbstractMenu> i_SubMenus)
        {
            m_Name = i_Name;
            m_MenuItems = i_SubMenus;
            m_LevelInMenu = 1;
            if (i_SubMenus != null)
            {
                m_ItemType = i_SubMenus.Count == 0 ? eItemType.Action : eItemType.Menu;
            }
        }

        public SubMenuItem(string i_Name, Dictionary<int, AbstractMenu> i_SubMenus, SubMenuItem io_Base)
        {
            m_LevelInMenu = 1;
            m_Name = i_Name;
            m_MenuItems = i_SubMenus;
            if (i_SubMenus != null)
            {
                m_ItemType = i_SubMenus.Count == 0 ? eItemType.Action : eItemType.Menu;
            }

            m_Base = io_Base;
            if (io_Base != null)
            {
                m_LevelInMenu += io_Base.m_LevelInMenu;
                io_Base.AddItem(this);
            }
        }

        public virtual void AddItem(AbstractMenu i_Item)
        {
            GoBackMenuItem goBack;
            if (m_ItemType == eItemType.Action)
            {
                goBack = new GoBackMenuItem();
                goBack.setBase(this);
                m_MenuItems.Add(0, goBack);
                m_ItemType = eItemType.Menu;
            }

            m_MenuItems.Add(m_MenuItems.Count, i_Item);
        }

        private void setBase(SubMenuItem i_Base)
        {
            m_Base = i_Base;
        }

        public override void Show()
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

        public override string ToString()
        {
            StringBuilder consoleMessege = new StringBuilder();
            consoleMessege.Append($"Current Menu Level: {m_LevelInMenu}{Environment.NewLine}");

            foreach (KeyValuePair<int, AbstractMenu> item in m_MenuItems.Skip(1))
            {
                consoleMessege.Append(singleAbstractMenuToString(item));
            }

            consoleMessege.Append(singleAbstractMenuToString(m_MenuItems.First()));
            consoleMessege.Remove(consoleMessege.Length - 1, 1);

            return consoleMessege.ToString();
        }

        private string singleAbstractMenuToString(KeyValuePair<int, AbstractMenu> i_DictionaryItem)
        {
            string actionType = i_DictionaryItem.Value.ItemType == eItemType.Action ? "Action" : "Sub Menu";

            return string.Format("{0}. {1}({2}){3}", i_DictionaryItem.Key, i_DictionaryItem.Value.Name, actionType, Environment.NewLine);
        }
    }
}
