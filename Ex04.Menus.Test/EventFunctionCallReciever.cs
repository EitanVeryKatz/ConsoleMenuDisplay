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
        public EventFunctionCallReciever(Events.MainMenu i_menu)
        {
            i_menu.NonSubMenuItemChosen += ReportChosen;
        }
        internal void ReportChosen(string i_MenuItemName)
        {
            if (i_MenuItemName == "Show Version")
            {
                Console.WriteLine("Version 1.0.0");
                Thread.Sleep(1000);
            }
            else if (i_MenuItemName == "Count Lowercase Letters")
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
            else if (i_MenuItemName == "Show Current Date")
            {
                Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
                Thread.Sleep(1000);

            }
            else if (i_MenuItemName == "Show Current Time")
            {
                Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"Menu item '{i_MenuItemName}' has been chosen, but no action is defined for it.");
            }
        }

        public Action<string> GetAction()
        {
            return ReportChosen;
        }
    }
}
