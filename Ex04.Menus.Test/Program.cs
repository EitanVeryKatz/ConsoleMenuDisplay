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
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Main Menu", functions); // Fixed ambiguity
            mainMenu.AddSubMenu("Sub Menu 1");
            mainMenu.AddSubMenu("Sub Menu 2");
            mainMenu.EnterSubMenu("Sub Menu 1");
            mainMenu.AddMenuItem("Item 1");
            mainMenu.AddMenuItem("Item 2");
            mainMenu.ResetToDefaultMenu();
            mainMenu.EnterSubMenu("Sub Menu 2");
            mainMenu.AddMenuItem("Item 3");
            mainMenu.ResetToDefaultMenu();
            mainMenu.Show();
        }
        public static void testEvents()
        {
            FunctionsEvents functions = new FunctionsEvents();
            Console.WriteLine("Testing Events Menu System...");
            Events.MainMenu mainMenu = new Events.MainMenu("Main Menu", functions);
            mainMenu.AddSubMenu("Sub Menu 1");
            mainMenu.AddSubMenu("Sub Menu 2");
            mainMenu.EnterSubMenu("Sub Menu 1");
            mainMenu.AddMenuItem("Item 1");
            mainMenu.AddMenuItem("Item 2");
            mainMenu.ResetToDefaultMenu();
            mainMenu.EnterSubMenu("Sub Menu 2");
            mainMenu.AddMenuItem("Item 3");
            mainMenu.ResetToDefaultMenu();
            mainMenu.Show();
        }
    }
}
