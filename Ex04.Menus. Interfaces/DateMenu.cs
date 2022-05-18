using System;

namespace Ex04.Menus.Interfaces
{
    public interface IDateObserver
    {
        DateTime ReportDate();
    }

    public class MenuItemDate : MenuItem, IMenuObserver
    {
        public void Show()
        {
            foreach (IDateObserver observer in r_MenuObservers)
            {
                Console.WriteLine(observer.ReportDate().ToString("dd/MM/yyyy"));
            }
        }
    }
}