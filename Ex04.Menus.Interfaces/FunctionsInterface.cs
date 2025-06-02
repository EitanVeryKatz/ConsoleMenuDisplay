using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class FunctionsInterface : IListener
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        void IListener.ReportChosen(MenuItem i_MenuItem)
        {
            if(i_MenuItem.Name == "Item 1")
            {
                Console.WriteLine("Item 1 execution");
                Thread.Sleep(1000); // Simulate some processing time
            }
            else if (i_MenuItem.Name == "Item 2")
            {
                Console.WriteLine("Item 2 execution");
                Thread.Sleep(1000); // Simulate some processing time

            }
            else if (i_MenuItem.Name == "Item 3")
            {
                Console.WriteLine("Item 3 execution");
                Thread.Sleep(1000); // Simulate some processing time

            }
        }
    }
}

