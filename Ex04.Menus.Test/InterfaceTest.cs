namespace Ex04.Menus.Test
{
    using System.Collections.Generic;
    using Ex04.Menus.Interfaces;
    using Ex04.Menus.Test.InterfaceMethods;

    public class InterfaceTest
    {
        private readonly MainMenu r_MainMenu;

        public InterfaceTest()
        {
            r_MainMenu = new MainMenu("Main delegates", new Dictionary<int, AbstractMenu>());
            SubMenuItem countSpacesAndShowVersion = new SubMenuItem("Version and Spaces", new Dictionary<int, AbstractMenu>(), r_MainMenu);
            SubMenuItem showTimeAndShowDate = new SubMenuItem("Shows Time/Date", new Dictionary<int, AbstractMenu>(), r_MainMenu);
            addSpacesAndShowVersion(countSpacesAndShowVersion);
            addShowTimeAndShowDate(showTimeAndShowDate);
        }

        public void Run()
        {
            r_MainMenu.Show();
        }

        private void addShowTimeAndShowDate(SubMenuItem i_ShowTimeAndShowDate)
        {
            new DateMenu("Show date", i_ShowTimeAndShowDate);
            new TimeMenu("Show Time", i_ShowTimeAndShowDate);
        }

        private void addSpacesAndShowVersion(SubMenuItem countSpacesAndShowVersion)
        {
            new SpacesMenu("Count spaces", countSpacesAndShowVersion);
            new VersionMenu("Show Version", countSpacesAndShowVersion);
        }
    }
}