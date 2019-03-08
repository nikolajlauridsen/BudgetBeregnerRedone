using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Domain
{
    public abstract class Entry
    {
        public string Name;
        public double Amount;

        public Entry(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
