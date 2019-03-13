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
        public readonly int ID;

        public Entry(string name, double amount, int id)
        {
            Name = name;
            Amount = amount;
            ID = id;
        }
    }
}
