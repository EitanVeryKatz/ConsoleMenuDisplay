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
        Action<MenuItem> NonSubMenuItemChosen;

        public MainMenu(string i_Title, FunctionsEvents functions)
        {
            CurrentMenu = new SubMenu(i_Title);
            CurrentMenu.Chosen += On_Chosen;
            CurrentMenu.SwitchBackToExit();
            m_DefaultMenu = CurrentMenu;
            if (functions?.GetAction() != null)
            {
                NonSubMenuItemChosen = functions.GetAction();
            }
            else
            {
                throw new ArgumentNullException(nameof(functions), "FunctionsEvents instance cannot be null or must provide a valid action.");
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            CurrentMenu.AddMenuItem(i_MenuItem);
            i_MenuItem.Chosen += On_Chosen;
        }

        public void AddMenuItem(string i_Name)
        {
            MenuItem menuItem = new MenuItem(i_Name);
            menuItem.Chosen += On_Chosen;
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
            Ex02.ConsoleUtils.Screen.Clear();
            m_isRunning = true;
            while (m_isRunning)
            {
                CurrentMenu.Show();
                CurrentMenu.HandleInput();
            }
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
                else
                {
                    NonSubMenuItemChosen.Invoke(i_MenuItem);
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