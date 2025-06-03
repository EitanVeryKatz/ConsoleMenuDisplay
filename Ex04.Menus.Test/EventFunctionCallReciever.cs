using Ex04.Menus.Events;
using System;
using System.Threading;

namespace Ex04.Menus.Test
{
    internal class EventFunctionCallReciever
    {
        private string k_Version;

        public void addEventForAllItems(MainMenu i_Menu)
        {
            i_Menu.ResetToDefaultMenu();
            i_Menu.EnterSubMenu("Letters and Version");
            i_Menu.GetMenuItemFromCurrentSubMenu("Show Version").Chosen += showVersion;
            i_Menu.GetMenuItemFromCurrentSubMenu("Count Lowercase Letters").Chosen += countLowercaseLetters;
            i_Menu.ResetToDefaultMenu();
            i_Menu.EnterSubMenu("Show Current Date/Time");
            i_Menu.GetMenuItemFromCurrentSubMenu("Show Current Date").Chosen += showCurrentDate;
            i_Menu.GetMenuItemFromCurrentSubMenu("Show Current Time").Chosen += showCurrentTime;
        }

        private void showVersion(MenuItem i_MenuItem)
        {
            Console.WriteLine("Version {0}", k_Version);
            Thread.Sleep(1000);
        }

        private void countLowercaseLetters(MenuItem i_MenuItem)
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

            Console.WriteLine("Number of lowercase letters in sentaece is: {0}", lowerCaseLetterCounter);
            Thread.Sleep(1000);
        }

        private void showCurrentDate(MenuItem i_MenuItem)
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
            Thread.Sleep(1000);
        }

        private void showCurrentTime(MenuItem i_MenuItem)
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
            Thread.Sleep(1000);
        }
    }
}
