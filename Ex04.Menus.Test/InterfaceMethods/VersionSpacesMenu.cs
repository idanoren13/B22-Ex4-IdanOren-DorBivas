﻿namespace Ex04.Menus.Test.InterfaceMethods
{
    using System;
    using System.Collections.Generic;
    using Ex04.Menus.Interfaces;

    public class VersionSpacesMenu : SubMenuItem
    {
        public VersionSpacesMenu(string i_Name, Dictionary<int, AbstractMenu> i_SubMenus, SubMenuItem io_Base) : base(i_Name, i_SubMenus, io_Base)
        {
        }
    }
}