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
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public void ReportChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem.Name == "Show Version")
            {
                Console.WriteLine("Version 1.0.0"); // Example version output
                Thread.Sleep(1000); // Simulate some processing time
            }
            else if (i_MenuItem.Name == "Count Lowercase Letters")
            {
                Console.WriteLine("Counting lowercase letters in a sample string...");
                Thread.Sleep(1000); // Simulate some processing time

            }
            else if (i_MenuItem.Name == "Show Current Date")
            {
                Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
                Thread.Sleep(1000); // Simulate some processing time

            }
            else if (i_MenuItem.Name == "Show Current Time")
            {
                Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
                Thread.Sleep(1000); // Simulate some processing time
            }
            else
            {
                Console.WriteLine($"Menu item '{i_MenuItem.Name}' has been chosen, but no action is defined for it.");
            }
        }

        //Expose an Action that can be invoked
        public Action<MenuItem> GetAction()
        {
            return ReportChosen;
        }
    }
}