using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BudgetLibrary.Application;
using BudgetLibrary.Model;

namespace BudgetLibrary
{
    public class BudgetRepository
    {        
        public int CalculateDisposableIncome(List<int> incomeList, List<int> expensesList)
        {
            int incomeSum = incomeList.Sum();
            int expensesSum = expensesList.Sum();
            return incomeSum - expensesSum;
        }

        public void SaveBudget(List<string> incomeColumn, List<string> expenseColumn, List<int> incomeList, List<int> expensesList)
        {
            Console.Write("Skriv et navn til dit budget: ");
            string name = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine("Indtægter");
                for (int i = 0; i < incomeColumn.Count; i++)
                {
                    if (incomeList[i] != 0)
                    {
                        sw.WriteLine(incomeColumn[i] + " " + incomeList[i]);
                    }                    
                }
                sw.WriteLine();
                sw.WriteLine("Udgifter");
                for (int i = 0; i < expenseColumn.Count; i++)
                {
                    if (expensesList[i] != 0)
                    {
                        sw.WriteLine(expenseColumn[i] + " " + expensesList[i]);
                    }                    
                }
                sw.WriteLine("_____________________________________");
                sw.WriteLine("Rådighedsbeløb: "+CalculateDisposableIncome(incomeList, expensesList));
            }

            Console.WriteLine("\nDit budget er blevet gemt.");                
        }
    }
}