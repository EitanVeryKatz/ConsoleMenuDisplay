using System;
using System.Collections;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly Stack r_HistoryStack = new Stack();
        private readonly SubMenu r_DefaultMenu;
        public event Action<string> NonSubMenuItemChosen;
        private bool m_isRunning = false;
        private SubMenu CurrentMenu { get; set; } = null;

        public MainMenu(string i_Title)
        {
            CurrentMenu = new SubMenu(i_Title);
            CurrentMenu.Chosen += menuItem_Chosen;
            CurrentMenu.SwitchBackToExit();
            CurrentMenu.GetItem("Exit").Chosen += menuItem_Chosen;
            r_DefaultMenu = CurrentMenu;
        }

        public void AddMenuItem(string i_Name)
        {
            MenuItem menuItem = new MenuItem(i_Name);

            CurrentMenu.AddMenuItem(menuItem);
        }

        public void AddSubMenu(string i_Name)
        {
            SubMenu subMenu = new SubMenu(i_Name);

            subMenu.GetItem("Back").Chosen += menuItem_Chosen;
            subMenu.Chosen += menuItem_Chosen;
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

        public MenuItem GetMenuItemFromCurrentSubMenu(string i_ItemName)
        {
            return CurrentMenu.GetItem(i_ItemName);
        }

        private void menuItem_Chosen(MenuItem i_MenuItem)
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
            CurrentMenu = r_DefaultMenu;
            r_HistoryStack.Clear();
        }
    }
}