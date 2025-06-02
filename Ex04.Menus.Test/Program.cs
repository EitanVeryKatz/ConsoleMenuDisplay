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
            MenuSystemTest();
        }
        public static void MenuSystemTest()
        {
            Console.WriteLine("Welcome to the Menu System Test!");
            Console.WriteLine("Please choose a menu system to test:\n1- interface\n2- events");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                testInterfaces();
            }
            else if (choice == 2)
            {
                testEvents();
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting.");
            }
        }
        public static void testInterfaces()
        {
            Console.WriteLine("Testing Interfaces Menu System...");
            FunctionsInterface functions = new FunctionsInterface();
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
        public static void testEvents()
        {
            FunctionsEvents functions = new FunctionsEvents();
            Console.WriteLine("Testing Events Menu System...");
            Events.MainMenu mainMenu = new Events.MainMenu("Delegates Main Menu", functions);//main menu
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
        })
    }
}
