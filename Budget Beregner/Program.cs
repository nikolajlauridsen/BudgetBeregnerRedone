using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BudgetLibrary.Persistence;
using BudgetLibrary.Domain;

namespace Budget_Beregner
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Program myProgram = new Program();
            myProgram.Run();
            */

            Budget budget = SQLConnector.Instance.SaveBudget("Test8", null, null);

            Budget myBudget = SQLConnector.Instance.GetBudget(budget.ID);
            Console.WriteLine($"Budget: {myBudget.Name} ID: {myBudget.ID}");

            Console.WriteLine("Incomes: ");
            foreach(Income income in myBudget.Incomes) Console.WriteLine($"{income.Name}: {income.Amount}");

            Console.WriteLine("Expenses: ");
            foreach (Expense expense in myBudget.Expenses) Console.WriteLine($"{expense.Name}: {expense.Amount}");
            Console.ReadKey(true);
        }

        void Run()
        {
            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
