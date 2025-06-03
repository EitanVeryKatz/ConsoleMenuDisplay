using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Events
{
    internal class SubMenu : MenuItem
    {
        private readonly Dictionary<int, MenuItem> r_MenuItems = new Dictionary<int, MenuItem>();

        public SubMenu(string i_Name) : base(i_Name)
        {
            r_MenuItems.Add(0, new MenuItem("Back"));
        }

        internal void SwitchBackToExit()
        {
            r_MenuItems[0] = new MenuItem("Exit");
        }

        internal void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(r_MenuItems.Count, i_MenuItem);
        }

        internal void AddMenuItem(string i_Name)
        {
            MenuItem menuItem = new MenuItem(i_Name);

            r_MenuItems.Add(r_MenuItems.Count, menuItem);
        }

        internal MenuItem GetItem(string i_ItemName)
        {
            MenuItem itemToReturn = null;

            foreach (MenuItem menuItem in r_MenuItems.Values)
            {
                if (!(menuItem is SubMenu) && menuItem.Name == i_ItemName)
                {
                    itemToReturn = menuItem;
                    break;
                }
            }

            return itemToReturn;
        }

        internal void Show()
        {
            Console.Clear();
            Console.WriteLine("** {0} **", Name);
            Console.WriteLine("-----------------------------");
            foreach (KeyValuePair<int, MenuItem> menuItem in r_MenuItems)
            {
                if (menuItem.Key == 0 && r_MenuItems.Count > 1)
                {
                    continue;
                }

                Console.WriteLine($"{menuItem.Key}. {menuItem.Value.Name}");
            }

            if (r_MenuItems.Count > 1)
            {
                Console.WriteLine("0. {0}", r_MenuItems[0].Name);
            }
        }

        public void HandleInput()
        {
            string choice = getInput();
            MenuItem selectedItem = r_MenuItems[int.Parse(choice)];

            if (selectedItem != null)
            {
                OnChosen(selectedItem);
            }
        }

        private string getInput()
        {
            if (r_MenuItems[0].Name == "Exit")
            {
                Console.WriteLine("Please enter your choice (1-{0} or 0 to exit):", r_MenuItems.Count - 1);
            }
            else
            {
                Console.WriteLine("Please enter your choice (1-{0} or 0 to go back):", r_MenuItems.Count - 1);
            }

            string inputStr = Console.ReadLine();

            if (string.IsNullOrEmpty(inputStr))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                inputStr = getInput();
            }

            if (!int.TryParse(inputStr, out int inputInteger) || !r_MenuItems.ContainsKey(inputInteger))
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(1000);
                Show();
                inputStr = getInput();
            }

            Console.Clear();

            return inputStr;
        }

        internal void TryEnter(string i_SubMenuName)
        {
            foreach (MenuItem menuItem in r_MenuItems.Values)
            {
                if (menuItem is SubMenu subMenuToEnter && menuItem.Name == i_SubMenuName)
                {
                    OnChosen(subMenuToEnter);
                    break;
                }
            }
        }
    }
}
