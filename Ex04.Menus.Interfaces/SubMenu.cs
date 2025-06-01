using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    internal class SubMenu : MenuItem
    {
        private readonly Dictionary<int, MenuItem> r_MenuItems = new Dictionary<int, MenuItem>();
        public SubMenu(string i_Name, IListener i_Listener) : base(i_Name, i_Listener)
        {
        }
        private void AddItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(r_MenuItems.Count+1,i_MenuItem);
        }

        internal void Show()// Override the Show method to display submenu items
        {
            //add clear screen
            Console.WriteLine($"Sub Menu: {Name}");
            foreach (KeyValuePair<int,MenuItem> item in r_MenuItems)
            {
                Console.WriteLine($"{item.Key}. {item.Value.Name}");
            }
                
        }

        public void HandleInput()
        {
            string choice = getInput();
            MenuItem selectedItem = r_MenuItems[int.Parse(choice)];
            if (selectedItem != null)
            {
                selectedItem.ReportChosen();// Notify the listener that an item has been chosen
            }
        }

        private string getInput()
        {
            Console.WriteLine("Please choose an option:");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                return getInput();
            }
            if (!r_MenuItems.ContainsKey(int.Parse(input)))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return getInput();
            }
            return input;
        }

    }
}