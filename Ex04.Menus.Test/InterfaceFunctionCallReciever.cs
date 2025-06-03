using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class InterfaceFunctionCallReciever:IListener<string>
    {
        private readonly MenuFunctionInvoker r_MenuFunctionsInvoker = new MenuFunctionInvoker();
        void IListener<string>.ReportChosen(string i_MenuItemName)
        {
            r_MenuFunctionsInvoker.InvokeMenuOption(i_MenuItemName);
        }
    }
}
