using System;

namespace Ex04.Menus.Interfaces
{
    public interface ISpacesObserver 
    {
        int ReportSpaces(string i_Input);
    }

    public class ISpacesMenu : AbstractMenu, IMenuObserver
    {
        public void Show()
        {
            Console.WriteLine("Write here what ever you comes in ur skuwantzch:");  ///todo
            string input = Console.ReadLine();
            foreach (ISpacesObserver observer in r_MenuObservers)
            {
                Console.WriteLine("Number of spaces: {0}", observer.ReportSpaces(input));
            }
        }
    }
}