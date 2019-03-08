using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Domain
{
    class Income : Expense
    {
        public Income(string name, double quantity) : base(name, quantity)
        {

        }
    }
}
