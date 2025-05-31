using System;

namespace Ex04.Menus.Test
{
    internal class MenuItem
    {
        public string Name { get; private set; }
        private IListener m_Listener;

        internal MenuItem(string name, IListener listener = null)
        {
            Name = name;
            m_Listener = listener;
        }

        internal void SetListener(IListener listener)
        {
            m_Listener = listener;
        }

        internal virtual void Show()
        {
            Console.WriteLine($"Menu Item: {Name}");
        }

        internal void ReportChosen()
        {
            if (m_Listener != null)
            {
                m_Listener.NotifyChosen(Name);
            }
            else
            {
                Console.WriteLine($"Menu item '{Name}' has been chosen, but no listener is registered.");
            }
        }
    }
}