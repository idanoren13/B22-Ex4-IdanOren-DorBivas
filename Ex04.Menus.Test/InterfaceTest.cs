namespace Ex04.Menus.Test
{
    using System.Collections.Generic;
    using Ex04.Menus.Interfaces;
    using Ex04.Menus.Test.InterfaceMethods;

    public class InterfaceTest
    {
        private readonly MainMenu r_InterFaceMenu;

        public InterfaceTest()
        {
            r_InterFaceMenu = new MainMenu("Main delegates", new Dictionary<int, AbstractMenu>());
            SubMenuItem countSpacesAndShowVersion = new SubMenuItem("Version and Spaces", new Dictionary<int, AbstractMenu>(), r_InterFaceMenu);
            SubMenuItem showTimeAndShowDate = new SubMenuItem("Shows Time/Date", new Dictionary<int, AbstractMenu>(), r_InterFaceMenu);
            addSpacesAndShowVersion(countSpacesAndShowVersion);
            addShowTimeAndShowDate(showTimeAndShowDate);
        }

        public void Run()
        {
            r_InterFaceMenu.Show();
        }

        private void addShowTimeAndShowDate(SubMenuItem i_ShowTimeAndShowDate)
        {
            new DateMenu("Show date", i_ShowTimeAndShowDate);
            new TimeMenu("Show Time", i_ShowTimeAndShowDate);
        }

        private void addSpacesAndShowVersion(SubMenuItem i_CountSpacesAndShowVersion)
        {
            new SpacesMenu("Count spaces", i_CountSpacesAndShowVersion);
            new VersionMenu("Show Version", i_CountSpacesAndShowVersion);
        }
    }
}