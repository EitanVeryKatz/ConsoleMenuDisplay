using System;

namespace Ex04.Menus.Events
{
    internal class MenuActionItem : MenuItem
    {
        public MenuActionItem(string i_Name) : base(i_Name) { }
        public event Action Activated;
    }
}
