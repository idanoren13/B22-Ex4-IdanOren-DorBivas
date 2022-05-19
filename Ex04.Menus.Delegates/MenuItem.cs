using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public enum eItemType
        {
            Action,
            Menu
        }

        private readonly int m_LevelInMenu;
        private bool m_continueShowLoop = true;
        private string m_Name;
        private MenuItem m_Base;
        protected eItemType m_ItemType;
        protected List<MenuItem> m_SubMenus;
        public event Action<MenuItem> Chosen;

        protected MenuItem(string i_Name, List<MenuItem> i_SubMenus)
        {
            m_Name = i_Name;
            m_SubMenus = i_SubMenus;
            m_LevelInMenu = 1;
            if (i_SubMenus != null)
            {
                m_ItemType = i_SubMenus.Count == 0 ? eItemType.Action : eItemType.Menu;
            }
        }

        public MenuItem(string i_Name, List<MenuItem> i_SubMenus, MenuItem io_RBase)
        {
            m_LevelInMenu = 1;
            m_Name = i_Name;
            m_SubMenus = i_SubMenus;
            if (i_SubMenus != null)
            {
                m_ItemType = i_SubMenus.Count == 0 ? eItemType.Action : eItemType.Menu;
            }
            
            m_Base = io_RBase;
            if (io_RBase != null)
            {
                m_LevelInMenu += io_RBase.m_LevelInMenu;
                io_RBase.AddItem(this);
            }
        }

        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }

        private eItemType ItemType
        {
            get => m_ItemType;
        }

        public virtual void AddItem(MenuItem i_Item)
        {
            MenuItem goBack;
            if (m_ItemType == eItemType.Action)
            {
                goBack = new MenuItem("Go Back", null);
                goBack.setBase(this);
                goBack.Chosen += goBackRequest_Chosen;
                m_SubMenus.Add(goBack);
                m_ItemType = eItemType.Menu;
            }

            m_SubMenus.Insert(0, i_Item);
        }

        private void goBackRequest_Chosen(MenuItem i_MenuItem)
        {
            m_continueShowLoop = false;
            Console.Clear();
        }

        public void goFowradRequest_Chosen(MenuItem i_MenuItem)
        {
            m_continueShowLoop = true;
            Console.Clear();
            i_MenuItem.Show();
        }

        private void aMethodForWindowsToTellMeIWasClicked()
        {
            Console.WriteLine("An input has been entered.");
            OnChoosig();
        }

        private void OnChoosig()
        {
            if (Chosen != null)
            {
                Chosen.Invoke(this);
            }
        }

        private void setBase(MenuItem i_Base)
        {
            m_Base = i_Base;
        }

        public void Show()
        {
            uint parsedChoice;
            bool isValid;

            while (m_continueShowLoop)
            {
                Console.WriteLine(this.ToString());
                isValid = uint.TryParse(Console.ReadLine(), out parsedChoice);
                while (!isValid || parsedChoice >= m_SubMenus.Count)
                {
                    Console.WriteLine($"ivalid input please enter number between 0 to {m_SubMenus.Count - 1}");
                    isValid = uint.TryParse(Console.ReadLine(), out parsedChoice);
                }

                Console.Clear();
                m_SubMenus[((int)parsedChoice)].aMethodForWindowsToTellMeIWasClicked(); 
            }
        }

        public override string ToString()
        {
            int i = 0;
            StringBuilder consoleMessege = new StringBuilder();
            consoleMessege.Append($"Current Menu Level: {m_LevelInMenu}{Environment.NewLine}");
            foreach (MenuItem item in m_SubMenus)
            {
                string actionType = item.ItemType == eItemType.Action ? "Action" : "Sub Menu";
                consoleMessege.Append(string.Format("{0}. {1}({2}){3}", i, item.Name, actionType, Environment.NewLine));
                i++;
            }

            consoleMessege.Remove(consoleMessege.Length - 1, 1);

            return consoleMessege.ToString();
        }
    }
}
