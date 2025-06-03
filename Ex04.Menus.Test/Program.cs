using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Main()
        {
            MenuTester tester = new MenuTester();

            tester.SetUpAndTestMenu();
        }
      
    }
}
