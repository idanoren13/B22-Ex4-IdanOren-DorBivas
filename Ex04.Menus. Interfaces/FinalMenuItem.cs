namespace Ex04.Menus.Interfaces
{
    public abstract class FinalMenuItem : AbstractMenu
    {
        public FinalMenuItem(string i_Name, SubMenuItem io_Base)
        {
            m_Name = i_Name;
            m_Base = io_Base;
            m_LevelInMenu += io_Base.Level;
            io_Base.AddItem(this);
        }

        public override void Show()
        {
            Act();
        }

        public abstract void Act();
    }
}
