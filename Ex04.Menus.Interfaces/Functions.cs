using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class Functions : IListener
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        void IListener.ReportChosen(MenuItem i_MenuItem)
        {
            if(i_MenuItem.Name == "item 1")
            {
                Console.WriteLine("item 1 execution");
            }
            else if (i_MenuItem.Name == "item 2")
            {
                Console.WriteLine("item 1 execution");
            }
            else if (i_MenuItem.Name == "item 3")
            {
                Console.WriteLine("item 1 execution");
            }
        }
    }
}

