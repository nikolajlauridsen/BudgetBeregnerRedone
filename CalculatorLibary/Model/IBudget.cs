using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Model
{
    public interface IBudget
    {
        string Name { get; }
        int ID { get; }
        List<IEntry> Incomes { get; }
        List<IEntry> Expenses { get; }

        double Income { get; }
        double Expense { get; }
        double DisposableIncome { get; }
    }
}
