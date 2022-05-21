namespace Ex04.Menus.Test.InterfaceMethods
{
    using System;
    using System.Linq;
    using Ex04.Menus.Interfaces;

    public class SpacesMenu : FinalMenuItem
    {
        public SpacesMenu(string i_Name, SubMenuItem io_Base) : base(i_Name, io_Base)
        {
        }

        public override void Act()
        {
            CountSpaces();
        }

        public void CountSpaces()
        {
            int numberOfSpaces = 0;
            string userInput;

            Console.WriteLine("Please enter a sentence: ");
            userInput = Console.ReadLine();
            numberOfSpaces = userInput.Count((char currentChar) => currentChar == ' ');
            Console.WriteLine("The number of spaces in the sentence is: {0}", numberOfSpaces);
        }
    }
}