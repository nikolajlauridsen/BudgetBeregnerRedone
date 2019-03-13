using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetLibrary.Domain;

namespace BudgetLibrary.Persistence
{
    public interface IDB
    {
        Budget GetBudget(string name);
        Budget GetBudget(int id);

        Budget SaveBudget(string name, List<Entry> incomes, List<Entry> entry);
        Budget SaveBudget(List<string> incomeColumn, List<string> expenseColumn, List<int> incomeList,
            List<int> expensesList);

        List<Budget> GetBudgets();

        void DeleteBudget(int id);
    }
}
