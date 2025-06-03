using System;

namespace Ex04.Menus.Interfaces
{
    internal class MenuItem
    {
        public string Name { get; private set; }
        protected IListener<MenuItem> m_Listener;

        public MenuItem(string i_Name, IListener<MenuItem> i_Listener = null)
        {
            Name = i_Name;
            m_Listener = i_Listener;
        }

        internal void SetListener(IListener<MenuItem> i_Listener)
        {
            m_Listener = i_Listener;
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