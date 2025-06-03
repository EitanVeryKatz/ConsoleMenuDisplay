using System;
using System.Collections;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IListener<MenuItem>
    {
        private readonly Stack r_HistoryStack = new Stack();
        private readonly SubMenu m_DefaultMenu;
        private bool m_isRunning = false;
        private IListener<string> m_Listener = null;
        private SubMenu CurrentMenu { get; set; } = null;

        public MainMenu(string i_Title, IListener<string> i_Listener)
        {
            m_Listener = i_Listener;
            CurrentMenu = new SubMenu(i_Title, this);
            CurrentMenu.SwitchBackToExit();
            m_DefaultMenu = CurrentMenu;
        }

        public void AddMenuItem(string i_Name)
        {
            MenuItem menuItem = new MenuItem(i_Name, this);

            CurrentMenu.AddMenuItem(menuItem);
        }

        public void AddSubMenu(string i_Name)
        {
            SubMenu subMenu = new SubMenu(i_Name, this);

            CurrentMenu.AddMenuItem(subMenu);
        }

        public void EnterSubMenu(string i_SubMenuName)
        {
            CurrentMenu.TryEnter(i_SubMenuName);
        }

        public void Show()
        {
            Console.Clear();
            m_isRunning = true;
            while (m_isRunning)
            {
                CurrentMenu.Show();
                CurrentMenu.HandleInput();
            }
        }

        void IListener<MenuItem>.ReportChosen(MenuItem i_MenuItem)
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
                    m_Listener.ReportChosen(i_MenuItem.Name);
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