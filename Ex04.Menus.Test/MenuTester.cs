using Ex04.Menus.Events;
using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class MenuTester
    {
        private void setUpAndTestInterfaces()
        {
            Console.WriteLine("Testing Interfaces Menu System...");
            InterfaceFunctionCallReciever functions = new InterfaceFunctionCallReciever();
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Delegates Main Menu", functions);//main menu
            mainMenu.AddSubMenu("Letters and Version");//submenu1
            mainMenu.AddSubMenu("Show Current Date/Time");//submenu2
            mainMenu.EnterSubMenu("Letters and Version");
            mainMenu.AddMenuItem("Show Version");
            mainMenu.AddMenuItem("Count Lowercase Letters");
            mainMenu.ResetToDefaultMenu();
            mainMenu.EnterSubMenu("Show Current Date/Time");
            mainMenu.AddMenuItem("Show Current Date");
            mainMenu.AddMenuItem("Show Current Time");
            mainMenu.ResetToDefaultMenu();
            mainMenu.Show();
        }

        private void setUpAndTestEvents()
        {
            Console.WriteLine("Testing Events Menu System...");
            Events.MainMenu mainMenu = new Events.MainMenu("Delegates Main Menu");//main menu
            EventFunctionCallReciever functions = new EventFunctionCallReciever(mainMenu);

            mainMenu.AddSubMenu("Letters and Version");//submenu1
            mainMenu.AddSubMenu("Show Current Date/Time");//submenu2
            mainMenu.EnterSubMenu("Letters and Version");
            mainMenu.AddMenuItem("Show Version");
            mainMenu.AddMenuItem("Count Lowercase Letters");
            mainMenu.ResetToDefaultMenu();
            mainMenu.EnterSubMenu("Show Current Date/Time");
            mainMenu.AddMenuItem("Show Current Date");
            mainMenu.AddMenuItem("Show Current Time");
            mainMenu.ResetToDefaultMenu();
            mainMenu.Show();
        }

        public void SetUpAndTestMenu()
        {
            Console.WriteLine("Welcome to the Menu System Test!");
            Console.WriteLine("Please choose a menu system to test:\n1- interface\n2- events");
            if(int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {
                    setUpAndTestInterfaces();
                }
                else if (choice == 2)
                {
                    setUpAndTestEvents();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting.");
            }

        }


    }
}
