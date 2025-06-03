using Ex04.Menus.Interfaces;
using System;
using System.Threading;

namespace Ex04.Menus.Test
{
    internal class InterfaceFunctionCallReciever : IListener<string>
    {
        private const string k_Version = "25.2.4.4480";

        void IListener<string>.ReportChosen(string i_MenuItemName)
        {
            switch (i_MenuItemName)
            {
                case "Show Version":
                    showVersion();
                    break;
                case "Count Lowercase Letters":
                    countLowercaseLetters();
                    break;
                case "Show Current Date":
                    showCurrentDate();
                    break;
                case "Show Current Time":
                    showCurrentTime();
                    break;
                default:
                    Console.WriteLine("Menu item '{0}' has been chosen, but no action is defined for it.", i_MenuItemName);
                    break;
            }
        }

        private void showVersion()
        {
            Console.WriteLine("Version {0}", k_Version);
            Thread.Sleep(1000);
        }

        private void countLowercaseLetters()
        {
            Console.WriteLine("Please enter a sentance for lower case letters count: ");
            string SentanceToCountLowerCase = Console.ReadLine();
            int lowerCaseLetterCounter = 0;

            foreach (char letter in SentanceToCountLowerCase)
            {
                if (char.IsLower(letter))
                {
                    lowerCaseLetterCounter++;
                }
            }

            Console.WriteLine("Number of lowercase letters in sentence is: {0}", lowerCaseLetterCounter);
            Thread.Sleep(1000);
        }

        private void showCurrentDate()
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
            Thread.Sleep(1000);
        }

        private void showCurrentTime()
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
            Thread.Sleep(1000);
        }
    }
}
