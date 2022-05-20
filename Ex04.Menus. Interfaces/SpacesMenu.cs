using System;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class SpacesMenu : AbstractMenu
    {
        public override void Show()
        {
            string input;
            int spaceCount;
   
            Console.WriteLine("Write here text to read the amount of spaces."); 
            input = Console.ReadLine();
            spaceCount = input.Count((char currentChar) => currentChar == ' ');
            Console.WriteLine($"Number of spaces: {spaceCount}");
        }
    }
}