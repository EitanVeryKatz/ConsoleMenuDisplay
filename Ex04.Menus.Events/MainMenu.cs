using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly Stack r_HistoryStack = new Stack();
        private bool m_isRunning = false;
        private SubMenu CurrentMenu { get; set; } = null;
        private readonly SubMenu m_DefaultMenu;
        Action<MenuItem> NonSubMenuItemChosen;

        public MainMenu(string i_Title)
        {
            CurrentMenu = new SubMenu(i_Title);
            CurrentMenu.Chosen += On_Chosen;
            CurrentMenu.SwitchBackToExit(); // Change "Back" to "Exit" in the default menu
            m_DefaultMenu = CurrentMenu; // Store the default menu
        }

        

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            CurrentMenu.AddItem(i_MenuItem);
            i_MenuItem.Chosen += On_Chosen;
        }


        public void EnterSubMenu(string i_SubMenuName)
        {
            CurrentMenu.TryEnter(i_SubMenuName);
        }

        public void Show()
        {
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
                    Console.WriteLine("{0} chosen", i_MenuItem.Name);
                    NonSubMenuItemChosen.Invoke(i_MenuItem); // Call the function associated with the menu item, if it exists
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

