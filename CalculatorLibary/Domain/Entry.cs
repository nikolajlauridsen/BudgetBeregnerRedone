using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetLibrary.Model;

namespace BudgetLibrary.Domain
{
    public abstract class Entry : IEntry
    {
        public string Name { get; }
        public double Amount { get; }
        public int ID { get; }

        public Entry(string name, double amount, int id)
        {
            Name = name;
            Amount = amount;
            ID = id;
        }
    }
}
