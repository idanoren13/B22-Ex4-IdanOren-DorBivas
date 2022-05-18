using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        enum eItemType
        {
            Menu,
            Action
        }

        private string m_Name;
        private List<MenuItem> m_SubMenus;// TODO: change name
        private MenuItem m_Base;
        private readonly int m_LevelInMenu;
        private event Action<MenuItem> m_Chosen;
        private eItemType m_ItemType;

        public MenuItem(string i_Name, List<MenuItem> i_SubMenus)
        {
            m_Name = i_Name;
            m_SubMenus = i_SubMenus;
            m_LevelInMenu = 1;
            m_ItemType = i_SubMenus == null ? eItemType.Action : eItemType.Menu;
        }

        public MenuItem(string i_Name, List<MenuItem> i_SubMenus, ref MenuItem io_RBase)
        {
            m_Name = i_Name;
            m_SubMenus = i_SubMenus;
            m_LevelInMenu = 1;
            m_Base = io_RBase;
            if (io_RBase != null)
            {
                m_LevelInMenu += io_RBase.m_LevelInMenu;
                io_RBase.AddItem(this);
            }

            m_ItemType = i_SubMenus == null ? eItemType.Action : eItemType.Menu;
        }
        //TODO : check access modifyers
        public MenuItem Base
        {
            get => m_Base;
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

        public virtual void AddItem(MenuItem i_Item)
        {
            MenuItem goBack;
            if (m_ItemType == eItemType.Action)
            {
                goBack = new MenuItem("Go Back", null);
                goBack.setBase(this);
                m_Chosen += goBackRequest;
                m_SubMenus.Add(goBack);
                m_ItemType = eItemType.Menu;
            }

            m_SubMenus.Add(i_Item);
        }

        protected virtual void goBackRequest(MenuItem i_MenuItem)
        {
            Console.Clear();
            i_MenuItem.m_Base.Base.Show();
        }

        private void aMethodForWindowsToTellMeIWasClicked()
        {
            Console.WriteLine("An input has been entered.");
            OnChosen(); //generic method
        }

        private void setBase(MenuItem i_Base)
        {
            m_Base = i_Base;
        }

        public void Show()
        {
            uint parsedChoice;

            Console.WriteLine(this.ToString());
            //TODO
            //string userChoice = Console.ReadLine();
            //parsedChoice = int.Parse(userChoice);
            while (!uint.TryParse(Console.ReadLine(),out parsedChoice) && parsedChoice >= m_SubMenus.Count)
            {
                Console.WriteLine($"{parsedChoice} is not available");
            }

            m_SubMenus[((int)parsedChoice)].
            //m_ItemsBelow[parsedChoice].aMethodForWindowsToTellMeIWasClicked();//TODO
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

            return consoleMessege.ToString();
        }
    }
}
