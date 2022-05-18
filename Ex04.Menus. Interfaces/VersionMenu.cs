﻿using System;

namespace Ex04.Menus.Interfaces
{
    public interface IVersionObserver
    {
        string ReportVersion();
    }

    public class VersionMenu : MenuItem, IMenuObserver
    {
        public void Show()
        {
            foreach (IVersionObserver observer in r_MenuObservers)
            {
                Console.WriteLine(observer.ReportVersion());
            }
        }
    }
}