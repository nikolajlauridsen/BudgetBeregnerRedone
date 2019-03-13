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

            /*
            Budget budgetToSave = new Budget("Hopefully the final test budget");
            budgetToSave.AddIncome("SU", 10000, -1);
            budgetToSave.AddIncome("Løn", 20000, -1);
            budgetToSave.AddExpense("Husleje", 10000, -1);
            budgetToSave.AddExpense("Benzin", 8000, -1);

            budgetToSave = SQLConnector.Instance.SaveBudget(budgetToSave.Name, budgetToSave.Incomes, budgetToSave.Expenses);
            */

            Budget myBudget = SQLConnector.Instance.GetBudget(10);
            Console.WriteLine($"Budget: {myBudget.Name}\nID: {myBudget.ID}");

            Console.WriteLine("\nIncomes: ");
            foreach(Income income in myBudget.Incomes) Console.WriteLine($"{income.Name}: {income.Amount}");

            Console.WriteLine("\nExpenses: ");
            foreach (Expense expense in myBudget.Expenses) Console.WriteLine($"{expense.Name}: {expense.Amount}");

            Console.WriteLine($"\nDisposable income: {myBudget.CalculateDisposableIncome()}");
            Console.ReadKey(true);
        }

        void Run()
        {
            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
