﻿using System;

namespace Ex04.Menus.Interfaces
{
    public interface ITimeObserver 
    {
        DateTime ReportTime();
    }

    public class ITimeMenu : AbstractMenu, IMenuObserver
    {
        public void Show()
        {
            foreach (ITimeObserver observer in r_MenuObservers)
            {
                Console.WriteLine(observer.ReportTime().ToString("HH:mm:ss"));
            }
        }
    }
}