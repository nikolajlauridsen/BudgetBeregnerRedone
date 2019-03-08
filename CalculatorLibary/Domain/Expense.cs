using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Domain
{
    public class Expense : Entry
    {
        public Expense(string name, double quantity) : base(name, quantity)
        {

        }
    }
}
