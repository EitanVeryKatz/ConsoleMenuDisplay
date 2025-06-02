using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        public string Name { get; private set; }

        public MenuItem(string name)
        {
            Name = name;
        }

        public event Action<MenuItem> Chosen;

        protected void OnChosen(MenuItem item)
        {
            Chosen?.Invoke(item);
        }
    }
}
