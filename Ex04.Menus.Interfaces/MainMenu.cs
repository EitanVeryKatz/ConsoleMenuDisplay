using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    internal class MainMenu : IListener
    {
        private Stack<SubMenu> historyStack = new Stack<SubMenu>();
        public SubMenu CurrentMenu { get; private set; } = null;
        private List<MenuItem> m_MenuItems = new List<MenuItem>();
        public MainMenu()
        {
            CurrentMenu = new SubMenu("Main Menu", this);
            historyStack.Push(CurrentMenu);
        }
        public MainMenu(string i_Title)
        {
            CurrentMenu = new SubMenu(i_Title, this);
            historyStack.Push(CurrentMenu);
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        public void Show()
        {
            Console.WriteLine("Main Menu:");
            foreach (MenuItem item in m_MenuItems)
            {
                if (item is Item menuItem)
                {
                    Console.WriteLine(menuItem.Text);
                }
                else if (item is SubMenu subMenu)
                {
                    Console.WriteLine(subMenu.Name);
                }
            }
        }

        private void ItemChosen(MenuItem i_MenuItem)
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
                    if (historyStack.Count > 0)
                    {
                        CurrentMenu = historyStack.Pop();
                        CurrentMenu.Show();
                    }
                    else
                    {
                        Console.WriteLine("No previous menu to return to.");
                    }
                }
                else
                {
                    item.Execute();
                }
            }
            else if (i_MenuItem is SubMenu subMenu)
            {
                historyStack.Push(CurrentMenu);
                CurrentMenu = subMenu;
                subMenu.Show();
            }
        }

        public void NotifyChosen(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }
}