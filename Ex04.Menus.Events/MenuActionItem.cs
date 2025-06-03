using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    internal class MenuActionItem:MenuItem
    {
        public MenuActionItem(string i_Name):base(i_Name) { }

        public event Action Activated;

        
    }
}
