using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ex02.ConsoleUtils;


namespace Ex04.Menus.Interfaces
{
    internal class SubMenu : MenuItem
    {
        private readonly Dictionary<int, MenuItem> r_MenuItems = new Dictionary<int, MenuItem>();
        public SubMenu(string i_Name, IListener<MenuItem> i_Listener) : base(i_Name, i_Listener)
        {
            r_MenuItems.Add(0, new MenuItem("Back", i_Listener));
        }

        internal void SwitchBackToExit()
        {
            r_MenuItems[0] = new MenuItem("Exit", m_Listener);
        }

        internal void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(r_MenuItems.Count, i_MenuItem);
        }

        internal void Show()
        {
            Console.Clear();
            Console.WriteLine("** {0} **", Name);
            Console.WriteLine("-----------------------------");
            foreach (KeyValuePair<int, MenuItem> item in r_MenuItems)
            {
                if (item.Key == 0 && r_MenuItems.Count > 1)
                {
                    continue;
                }

                Console.WriteLine($"{item.Key}. {item.Value.Name}");
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
                selectedItem.ReportChosen();
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
            if (!int.TryParse(inputStr,out int inputInteger) || !r_MenuItems.ContainsKey(inputInteger))
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