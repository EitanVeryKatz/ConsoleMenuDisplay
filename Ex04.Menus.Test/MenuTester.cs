using Ex04.Menus.Events;
using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    internal class MenuTester
    {
        private void setUpAndTestInterfaces()
        {
            Console.WriteLine("Testing Interfaces Menu System...");
            InterfaceFunctionCallReciever functions = new InterfaceFunctionCallReciever();
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Delegates Main Menu", functions);

            mainMenu.AddSubMenu("Letters and Version");
            mainMenu.AddSubMenu("Show Current Date/Time");
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
            Events.MainMenu mainMenu = new Events.MainMenu("Delegates Main Menu");
            EventFunctionCallReciever functions = new EventFunctionCallReciever();

            mainMenu.AddSubMenu("Letters and Version");
            mainMenu.AddSubMenu("Show Current Date/Time");
            mainMenu.EnterSubMenu("Letters and Version");
            mainMenu.AddMenuItem("Show Version");
            mainMenu.AddMenuItem("Count Lowercase Letters");
            mainMenu.ResetToDefaultMenu();
            mainMenu.EnterSubMenu("Show Current Date/Time");
            mainMenu.AddMenuItem("Show Current Date");
            mainMenu.AddMenuItem("Show Current Time");
            functions.addEventForAllItems(mainMenu);
            mainMenu.ResetToDefaultMenu();
            mainMenu.Show();
        }

        public void SetUpAndTestMenu()
        {
            Console.WriteLine("Welcome to the Menu System Test!");
            Console.WriteLine("Please choose a menu system to test:\n1- interface\n2- events");
            if (int.TryParse(Console.ReadLine(), out int choice))
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
