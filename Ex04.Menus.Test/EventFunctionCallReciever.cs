using Ex04.Menus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class EventFunctionCallReciever
    {
        private readonly MenuFunctionInvoker r_MenuFunctionsInvoker = new MenuFunctionInvoker();
        public EventFunctionCallReciever(Events.MainMenu i_menu)
        {
            i_menu.NonSubMenuItemChosen += ReportChosen;
        }
        internal void ReportChosen(string i_MenuItemName)
        {
           r_MenuFunctionsInvoker.InvokeMenuOption(i_MenuItemName);
        }

        public Action<string> GetAction()
        {
            return ReportChosen;
        }
    }
}
