using System;
using System.Collections.Generic;
using System.Collections;

namespace Ex04.Menus.Interfaces
{
    internal class MainMenu : IListener
    {
        private readonly Dictionary<string, MenuItem> r_MenuItems = new Dictionary<string, MenuItem>();
        private readonly Stack r_HistoryStack = new Stack();
        private bool m_isRunning = false;
        public SubMenu CurrentMenu { get; private set; } = null;
        private readonly SubMenu m_DefaultMenu;
        

        public MainMenu():this("Main Menu")
        {
        }

        public MainMenu(string i_Title)
        {
            CurrentMenu = new SubMenu(i_Title, this);
            m_DefaultMenu = CurrentMenu; // Store the default menu
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem.Name, i_MenuItem);//add set
            CurrentMenu.AddItem(i_MenuItem);
        }


        public void EnterSubMenu(string i_SubMenuName)
        {
            CurrentMenu.TryEnter(i_SubMenuName);
        }
        public void Show()
        {
            m_isRunning = true;
            CurrentMenu.Show();
            CurrentMenu.HandleInput();
        }
        
        void IListener.ReportChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem is SubMenu subMenu)
            {
                r_HistoryStack.Push(CurrentMenu);
                CurrentMenu = subMenu;
                if (m_isRunning)
                {
                    subMenu.Show();
                }
            }
            else
            {
                if (i_MenuItem.Name == "Exit")
                {
                    Console.WriteLine("Exiting menu...");
                    m_isRunning = false;
                }
                else if (i_MenuItem.Name == "Back")
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
                    i_MenuItem.ReportChosen();
                }
            }
        }

        public void ResetToDefaultMenu()
        {
            CurrentMenu = m_DefaultMenu;
            r_HistoryStack.Clear();
        }
    }
}