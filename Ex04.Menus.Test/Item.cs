using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class Item : MenuItem
    {
        // This class represents a menu item that can be executed.
        public string Text { get; private set; }
        public string Name { get; set; }
        public Item(string text)
        {
            Text = text;
        }
        public void Execute()
        {
            Console.WriteLine($"Executing item: {Text}");
        }
    }
}
