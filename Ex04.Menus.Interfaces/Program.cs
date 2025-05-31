using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu("Main Menu");
            
            // Create some menu items
            Item item1 = new Item("Option 1");
            Item item2 = new Item("Option 2");
            Item exitItem = new Item("Exit");
            // Create a submenu
            SubMenu subMenu = new SubMenu("Sub Menu", mainMenu);
            subMenu.AddSubMenuItem(item1);
            subMenu.AddSubMenuItem(item2);
            subMenu.AddSubMenuItem(exitItem);
            // Add the submenu to the main menu
            mainMenu.AddMenuItem(subMenu);
            // Show the main menu
            mainMenu.Show();
            // Handle input for the submenu
            subMenu.HandleInput();
        }
    }
}
