using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BudgetLibrary.Domain;
using BudgetLibrary.Model;
using BudgetLibrary.Persistence;

namespace BudgetLibrary.Application
{
    public class Controller
    {
        private static Controller _instance;

        public static Controller Instance => _instance ?? (_instance = new Controller());

        private Controller()
        {

        }

        public IBudget GetBudget(int id)
        {
            return SQLConnector.Instance.GetBudget(id);
        }

        public List<IBudget> GetBudgets()
        {
            return new List<IBudget>(SQLConnector.Instance.GetBudgets());
        }

        public void SaveBudget(string name, List<KeyValuePair<string, double>> incomes, List<KeyValuePair<string, double>> expenses)
        {
            List<Income> _incomes = new List<Income>();
            List<Expense> _expenses = new List<Expense>();

            foreach (KeyValuePair<string, double> income in incomes)
            {
                _incomes.Add(new Income(income.Key, income.Value, -1));
            }

            foreach (KeyValuePair<string, double> expense in expenses)
            {
                _expenses.Add(new Expense(expense.Key, expense.Value, -1));
            }

            SQLConnector.Instance.SaveBudget(name, _incomes, _expenses);
        }
    }
}
