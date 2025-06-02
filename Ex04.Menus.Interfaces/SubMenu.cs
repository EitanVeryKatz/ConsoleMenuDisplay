using System;
using System.Collections.Generic;
using System.Linq;
using Ex02.ConsoleUtils;


namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        private readonly Dictionary<int, MenuItem> r_MenuItems = new Dictionary<int, MenuItem>();
        public SubMenu(string i_Name, IListener i_Listener) : base(i_Name, i_Listener)
        {
            r_MenuItems.Add(0, new MenuItem("Back", i_Listener)); // Add a "Back" option
        }

        internal void SwitchBackToExit()
        {
            r_MenuItems[0] = new MenuItem("Exit", m_Listener); // Change "Back" to "Exit"
        }

        internal void AddItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(r_MenuItems.Count,i_MenuItem);
        }

        internal void Show()// Override the Show method to display submenu items
        {
            Ex02.ConsoleUtils.Screen.Clear(); //from guy ronen dll
            Console.WriteLine("** {0} **",Name);
            Console.WriteLine("******************");
            foreach (KeyValuePair<int,MenuItem> item in r_MenuItems)
            {
                if (item.Key == 0 && r_MenuItems.Count > 1)
                {
                    continue; // Skip the "Back" or "Exit" option for now
                }
                
                Console.WriteLine($"{item.Key}. {item.Value.Name}");
            }
            if (r_MenuItems.Count > 1)
            {
                Console.WriteLine("0. {0}", r_MenuItems[0].Name); // Print "Back" or "Exit" option last
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
            if (r_MenuItems[0].Name == "Exit")
            {
                Console.WriteLine("Please enter your choice (1-{0} or 0 to exit):", r_MenuItems.Count - 1);
            }
            else
            {
                Console.WriteLine("Please enter your choice (1-{0} or 0 to go back):", r_MenuItems.Count - 1);
            }
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

            Console.Clear();

            return input;
        }

        internal void TryEnter(string i_SubMenuName)
        {
            
            foreach (MenuItem item in r_MenuItems.Values)
            {
                if (item is SubMenu subMenuToEnter && item.Name == i_SubMenuName)
                {
                    subMenuToEnter.ReportChosen();
                    break;
                }
            }
        }
    }
}