using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Main()
        {
            //Functions functions = new Functions();
            //MainMenu mainMenu = new MainMenu("Main Menu", functions);

            //mainMenu.AddSubMenu("Sub Menu 1");
            //mainMenu.AddSubMenu("Sub Menu 2");
            //mainMenu.EnterSubMenu("Sub Menu 1");
            //mainMenu.AddMenuItem("Item 1");
            //mainMenu.AddMenuItem("Item 2");
            //mainMenu.ResetToDefaultMenu();
            //mainMenu.EnterSubMenu("Sub Menu 2");
            //mainMenu.AddMenuItem("Item 3");
            //mainMenu.ResetToDefaultMenu();
            //mainMenu.Show();



            Events.MainMenu mainMenu = new Events.MainMenu("Main Menu");
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
