using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class Program
    {
        public static void Main()
        {
            MainMenu mainMenu = new MainMenu("Main Menu");
            //MainMenu mainMenu = new MainMenu();

            SubMenu subMenu1 = new SubMenu("Sub Menu 1", mainMenu);
            SubMenu subMenu2 = new SubMenu("Sub Menu 2", mainMenu);
            MenuItem item1 = new MenuItem("Item 1", mainMenu);
            MenuItem item2 = new MenuItem("Item 2", mainMenu);
            MenuItem item3 = new MenuItem("Item 3", mainMenu);
            mainMenu.AddMenuItem(subMenu1);
            mainMenu.AddMenuItem(subMenu2);
            mainMenu.EnterSubMenu("Sub Menu 1");
            mainMenu.AddMenuItem(item1,someclass);
            mainMenu.AddMenuItem(item2);
            mainMenu.ResetToDefaultMenu();
            mainMenu.EnterSubMenu("Sub Menu 2");
            mainMenu.AddMenuItem(item3);
            mainMenu.ResetToDefaultMenu();
            mainMenu.Show();
        }
    }
}
