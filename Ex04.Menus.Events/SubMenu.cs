using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex04.Menus.Events
{
    public class SubMenu:MenuItem
    {
        private readonly Dictionary<int, MenuItem> r_MenuItems = new Dictionary<int, MenuItem>();
        public SubMenu(string i_Name) : base(i_Name)
        {
            r_MenuItems.Add(0, new MenuItem("Back")); // Add a "Back" option
        }

        internal void SwitchBackToExit()
        {
            r_MenuItems[0] = new MenuItem("Exit"); // Change "Back" to "Exit"
        }

        internal void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(r_MenuItems.Count, i_MenuItem);
        }

        internal void AddMenuItem(string i_Name)
        {
            MenuItem menuItem = new MenuItem(i_Name); // Create a new MenuItem
            r_MenuItems.Add(r_MenuItems.Count, menuItem); // Add it to the dictionary
        }

        internal void Show()// Override the Show method to display submenu items
        {
            Ex02.ConsoleUtils.Screen.Clear(); //from guy ronen dll
            Console.WriteLine("** {0} **", Name);
            Console.WriteLine("******************");
            foreach (KeyValuePair<int, MenuItem> item in r_MenuItems)
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
                OnChosen(selectedItem);// Notify the listener that an item has been chosen
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
            Ex02.ConsoleUtils.Screen.Clear(); // Clear the screen after input

            return input;
        }

        internal void TryEnter(string i_SubMenuName)
        {

            foreach (MenuItem item in r_MenuItems.Values)
            {
                if (item is SubMenu subMenuToEnter && item.Name == i_SubMenuName)
                {
                    OnChosen(subMenuToEnter);
                    break;
                }
            }
        }
    }
}
