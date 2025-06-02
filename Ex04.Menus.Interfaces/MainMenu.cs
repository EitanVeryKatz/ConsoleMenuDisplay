using System;
using System.Collections.Generic;
using System.Collections;
using Ex02.ConsoleUtils;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IListener
    {
        private readonly Stack r_HistoryStack = new Stack();
        private bool m_isRunning = false;
        private SubMenu CurrentMenu { get;  set; } = null;
        private readonly SubMenu m_DefaultMenu;
        private IListener m_Listener = null;


        public MainMenu(string i_Title,IListener i_Listener)
        {
            m_Listener = i_Listener;
            CurrentMenu = new SubMenu(i_Title, this);
            CurrentMenu.SwitchBackToExit(); // Change "Back" to "Exit" in the default menu
            m_DefaultMenu = CurrentMenu; // Store the default menu
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            CurrentMenu.AddItem(i_MenuItem);
        }


        public void AddMenuItem(string i_Name) //add menu item while creating one
        {
            MenuItem menuItem = new MenuItem(i_Name, this);
            CurrentMenu.AddItem(menuItem);
        }

        public void AddSubMenu(string i_Name)
        {
            SubMenu subMenu = new SubMenu(i_Name, this);
            CurrentMenu.AddItem(subMenu);
        }


        public void EnterSubMenu(string i_SubMenuName)
        {
            CurrentMenu.TryEnter(i_SubMenuName);
        }

        public void Show()
        {
            Ex02.ConsoleUtils.Screen.Clear();//from guy ronen dll
            m_isRunning = true;
            while (m_isRunning)
            {
                CurrentMenu.Show();
                CurrentMenu.HandleInput();
            }
            
        }
        
        void IListener.ReportChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem is SubMenu subMenu)
            {
                r_HistoryStack.Push(CurrentMenu);
                CurrentMenu = subMenu;
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
                    }
                    else
                    {
                        Console.WriteLine("No previous menu to return to.");
                    }
                }
                else
                {
                    Console.WriteLine("{0} chosen", i_MenuItem.Name);
                    m_Listener.ReportChosen(i_MenuItem); // Call the function associated with the menu item, if it exists
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