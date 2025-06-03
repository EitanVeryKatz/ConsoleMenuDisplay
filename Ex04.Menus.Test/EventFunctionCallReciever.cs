using Ex04.Menus.Events;
using System;
using System.Threading;

namespace Ex04.Menus.Test
{
    internal class EventFunctionCallReciever
    {
        private const string k_Version = "25.2.4.4480";

        public void addEventForAllItems(MainMenu i_Menu)
        {
            i_Menu.ResetToDefaultMenu();
            i_Menu.EnterSubMenu("Letters and Version");
            i_Menu.GetMenuItemFromCurrentSubMenu("Show Version").Chosen += menuItem_ChoseShowVersion;
            i_Menu.GetMenuItemFromCurrentSubMenu("Count Lowercase Letters").Chosen += menuItem_ChoseCountLowercaseLetters;
            i_Menu.ResetToDefaultMenu();
            i_Menu.EnterSubMenu("Show Current Date/Time");
            i_Menu.GetMenuItemFromCurrentSubMenu("Show Current Date").Chosen += menuItem_ChoseShowCurrentDate;
            i_Menu.GetMenuItemFromCurrentSubMenu("Show Current Time").Chosen += menuItem_ChoseShowCurrentTime;
        }

        private void menuItem_ChoseShowVersion(MenuItem i_MenuItem)
        {
            Console.WriteLine("Version {0}", k_Version);
            Thread.Sleep(1000);
        }

        private void menuItem_ChoseCountLowercaseLetters(MenuItem i_MenuItem)
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

        private void menuItem_ChoseShowCurrentDate(MenuItem i_MenuItem)
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
            Thread.Sleep(1000);
        }

        private void menuItem_ChoseShowCurrentTime(MenuItem i_MenuItem)
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
            Thread.Sleep(1000);
        }
    }
}
