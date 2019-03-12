using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Domain
{
    public class Budget
    {
        public string Name;

        private readonly List<Entry> _incomes = new List<Entry>();
        private readonly List<Entry> _expenses = new List<Entry>();

        public int ID;


        public Budget(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public Budget(string name) : this(name, -1)
        {

        }

        public void AddIncome(string name, double amount)
        {
            _incomes.Add(new Income(name, amount));
        }

        public void AddExpense(string name, double amount)
        {
            _expenses.Add(new Expense(name, amount));
        }

        public double CalculateDisposableIncome()
        {
            return _incomes.Sum(entry => entry.Amount) - _expenses.Sum(entry => entry.Amount);
        }

        public static double CalculateDisposableIncome(List<int> incomeList, List<int> expensesList)
        {
            int incomeSum = incomeList.Sum();
            int expensesSum = expensesList.Sum();
            return incomeSum - expensesSum;
        }
    }
}
