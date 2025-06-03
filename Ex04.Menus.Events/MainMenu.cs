using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly Stack r_HistoryStack = new Stack();
        private bool m_isRunning = false;
        private SubMenu CurrentMenu { get; set; } = null;
        private readonly SubMenu m_DefaultMenu;
        public event Action<string> NonSubMenuItemChosen;

        public MainMenu(string i_Title)
        {
            CurrentMenu = new SubMenu(i_Title);
            CurrentMenu.Chosen += On_Chosen;
            CurrentMenu.SwitchBackToExit();
            m_DefaultMenu = CurrentMenu;
        }

       
        public void AddMenuItem(string i_Name)
        {
            MenuItem menuItem = new MenuItem(i_Name);
            CurrentMenu.AddMenuItem(menuItem);
        }

        public void AddSubMenu(string i_Name)
        {
            SubMenu subMenu = new SubMenu(i_Name);
            subMenu.Chosen += On_Chosen;
            CurrentMenu.AddMenuItem(subMenu);
        }

        public void EnterSubMenu(string i_SubMenuName)
        {
            CurrentMenu.TryEnter(i_SubMenuName);
        }

        public void Show()
        {
            //ConsoleUtils.Screen.Clear();
            Console.Clear();
            m_isRunning = true;
            while (m_isRunning)
            {
                CurrentMenu.Show();
                CurrentMenu.HandleInput();
            }
        }

        public MenuItem GetMenuItemFromCurrentSubMenu(string i_ItemName)
        {
            return CurrentMenu.GetItem(i_ItemName);
        }

        void On_Chosen(MenuItem i_MenuItem)
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
                
            }
        }

        public void ResetToDefaultMenu()
        {
            CurrentMenu = m_DefaultMenu;
            r_HistoryStack.Clear();
        }
    }
}