using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    internal class SubMenu : MenuItem, IListener
    {
        private List<MenuItem> m_SubMenuItems = new List<MenuItem>();
        public string Name { get; private set; }
        public IListener Listener { get; private set; }
        public SubMenu(string i_Name, IListener i_Listener) : base(i_Name)
        {
            Name = i_Name;
            Listener = i_Listener;
        }
        public void AddSubMenuItem(MenuItem i_MenuItem)
        {
            i_MenuItem.SetListener(this); // Set this submenu as the listener
            m_SubMenuItems.Add(i_MenuItem);
        }

        public override void Show()// Override the Show method to display submenu items
        {
            Console.WriteLine($"Sub Menu: {Name}");
            for (int i = 0; i < m_SubMenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_SubMenuItems[i].Name}");
            }
        }

        public void HandleInput()
        {
            Show();// Display the submenu items
            string choice = getInput();
            MenuItem selectedItem = m_SubMenuItems.FirstOrDefault(item => item.Name.Equals(choice, StringComparison.OrdinalIgnoreCase));// Find the selected item based on user input
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
            if (!m_SubMenuItems.Any(item => item.Name.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return getInput();
            }
            return input;
        }

        public void NotifyChosen(string message)
        {
            Console.WriteLine($"You chose: {message} in submenu '{Name}'");
        }
    }
}