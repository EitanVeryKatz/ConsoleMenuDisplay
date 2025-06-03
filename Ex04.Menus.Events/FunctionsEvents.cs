using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex04.Menus.Events
{
    public class FunctionsEvents
    {
        public void ReportChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem.Name == "Show Version")
            {
                Console.WriteLine("Version 1.0.0");
                Thread.Sleep(1000);
            }
            else if (i_MenuItem.Name == "Count Lowercase Letters")
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
            else if (i_MenuItem.Name == "Show Current Date")
            {
                Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
                Thread.Sleep(1000);

            }
            else if (i_MenuItem.Name == "Show Current Time")
            {
                Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"Menu item '{i_MenuItem.Name}' has been chosen, but no action is defined for it.");
            }
        }

        public Action<MenuItem> GetAction()
        {
            return ReportChosen;
        }
    }
}