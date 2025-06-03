using System;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        public string Name { get; private set; }
        public event Action<MenuItem> Chosen;

        internal MenuItem(string i_Name)
        {
            Name = i_Name;
        }

        protected void OnChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem is SubMenu)
            {
                Chosen?.Invoke(i_MenuItem);
            }
            else
            {
                i_MenuItem.Chosen.Invoke(i_MenuItem);
            }
        }
    }
}
