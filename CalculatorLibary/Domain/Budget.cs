using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Domain
{
    public class Budget
    {
        public string Name;

        private readonly List<Income> _incomes = new List<Income>();
        private readonly List<Expense> _expenses = new List<Expense>();

        public int ID;


        public Budget(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public List<Income> Incomes => _incomes;
        public List<Expense> Expenses => _expenses;
        public Budget(string name) : this(name, -1)
        {

        }

        public void AddIncome(string name, double amount, int id)
        {
            _incomes.Add(new Income(name, amount, id));
        }

        public void AddExpense(string name, double amount, int id)
        {
            _expenses.Add(new Expense(name, amount, id));
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
