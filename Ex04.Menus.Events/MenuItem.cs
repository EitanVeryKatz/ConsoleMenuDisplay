using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    internal class MenuItem
    {
        public string Name { get; private set; }

  

        public MenuItem(string name)
        {
            Name = name;
        }


        internal void ReportChosen()
        {
            if (m_Listener != null)
            {
                m_Listener.ReportChosen(this);
            }
            else
            {
                Console.WriteLine($"Menu item '{Name}' has been chosen, but no listener is registered.");
            }
        }
    }
}
