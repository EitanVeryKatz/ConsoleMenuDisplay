using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        public string Name { get; private set; }
        protected IListener m_Listener;
        
        public MenuItem(string name, IListener listener = null)
        {
            Name = name;
            m_Listener = listener;
        }

        internal void SetListener(IListener listener)
        {
            m_Listener = listener;
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