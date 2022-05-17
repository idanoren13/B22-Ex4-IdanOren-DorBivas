using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_Name;
        private List<MenuItem> m_SubMenus;// TODO: change name
        private readonly MenuItem r_Base;
        private readonly int m_LevelInMenu;
        private event Action<MenuItem> m_Chosen;

        public MenuItem(string i_Name, List<MenuItem> i_SubMenus, MenuItem i_RBase)
        {
            m_Name = i_Name;
            m_SubMenus = i_SubMenus;
            m_LevelInMenu = 1;
            r_Base = i_RBase;
            if (i_RBase != null)
            {
                m_LevelInMenu += i_RBase.m_LevelInMenu;
            }
        }
        //TODO : check access modifyers
        public MenuItem Base
        {
            get => r_Base;
        }

        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }

        public List<MenuItem> SubMenus
        {
            get => m_SubMenus;
            set => m_SubMenus = value;
        }

        public int LevelInMenu
        {
            get => m_LevelInMenu;
        }

        public Action<MenuItem> Chosen
        {
            get => m_Chosen;
            set => m_Chosen = value;

        }

        public override string ToString()
        {
            StringBuilder consoleMessege = new StringBuilder();
            
            for (int i = 1; i < m_SubMenus.Count; i++)
            {
                string actionType = m_SubMenus[i] == null ? "Action" : "Sub Menu";
                consoleMessege.AppendLine(string.Format("{0}. {1}({2})", i, m_SubMenus[i].Name, actionType));
            }

            consoleMessege.AppendLine(string.Format("{0}. {1}({2})", 0, m_SubMenus[0].Name, "Action"));
            consoleMessege.AppendLine("Which opertion do you wish to operate");
            // TODO
            string userChoice = Console.ReadLine();
            int parsedChoice = int.Parse(userChoice);
            //m_ItemsBelow[parsedChoice].aMethodForWindowsToTellMeIWasClicked();//TODO

            return consoleMessege.ToString();
        }
    }
}
