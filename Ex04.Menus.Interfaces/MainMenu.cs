using System;
using System.Collections.Generic;
using System.Collections;

namespace Ex04.Menus.Interfaces
{
    internal class MainMenu : IListener
    {
        private readonly Dictionary<string, MenuItem> r_MenuItems = new Dictionary<string, MenuItem>();
        private readonly Stack r_HistoryStack = new Stack();
        public SubMenu CurrentMenu { get; private set; } = null;
        

        public MainMenu()
        {
            CurrentMenu = new SubMenu("Main Menu", this);
            r_HistoryStack.Push(CurrentMenu);
        }

        public MainMenu(string i_Title)
        {
            CurrentMenu = new SubMenu(i_Title, this);
            r_HistoryStack.Push(CurrentMenu);
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem.Name, i_MenuItem);//add set
        }

        public void Show()
        {
            CurrentMenu.Show();
            CurrentMenu.HandleInput();
        }
        
        void IListener.ReportChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem is Item item)
            {
                if (item.Name == "Exit")
                {
                    Console.WriteLine("Exiting menu...");
                    Environment.Exit(0);
                }
                else if (item.Name == "Back")
                {
                    if (r_HistoryStack.Count > 0)
                    {
                        CurrentMenu = (SubMenu)r_HistoryStack.Pop();
                        CurrentMenu.Show();
                    }
                    else
                    {
                        Console.WriteLine("No previous menu to return to.");
                    }
                }
                else
                {
                    item.ReportChosen();
                }
            }
            else if (i_MenuItem is SubMenu subMenu)
            {
                r_HistoryStack.Push(CurrentMenu);
                CurrentMenu = subMenu;
                subMenu.Show();
            }
        }

        
    }
}