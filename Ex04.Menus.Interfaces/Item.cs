using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class Item : MenuItem
    {
        public string Name { get;  set; }
        public Item(string Name, IListener listener = null) : base(Name, listener)
        {
        }
        public void Execute()
        {
            ReportChosen();
        }
    }
}
