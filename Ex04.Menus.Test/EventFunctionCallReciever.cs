using Ex04.Menus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class EventFunctionCallReciever
    {
        private string k_Version;

        public void addEventForAllItems(MainMenu i_menu)
        {
            i_menu.ResetToDefaultMenu();
            i_menu.EnterSubMenu("Letters and Version");
            i_menu.GetMenuItemFromCurrentSubMenu("Show Version").Chosen += showVersion;
            i_menu.GetMenuItemFromCurrentSubMenu("Count Lowercase Letters").Chosen += countLowercaseLetters;
            i_menu.ResetToDefaultMenu();
            i_menu.EnterSubMenu("Show Current Date/Time");
            i_menu.GetMenuItemFromCurrentSubMenu("Show Current Date").Chosen += showCurrentDate;
            i_menu.GetMenuItemFromCurrentSubMenu("Show Current Time").Chosen += showCurrentDate;

        }        

        private void showVersion(MenuItem menuItem)
        {
            Console.WriteLine("Version {0}", k_Version);
            Thread.Sleep(1000);
        }

        private void countLowercaseLetters(MenuItem menuItem)
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

            Console.WriteLine("Number of lowercase letters in sentance is: {0}", lowerCaseLetterCounter);
            Thread.Sleep(1000);
        }

        private void showCurrentDate(MenuItem menuItem)
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
            Thread.Sleep(1000);
        }

        private void showCurrentTime(MenuItem menuItem)
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
            Thread.Sleep(1000);
        }
        
    }
}
