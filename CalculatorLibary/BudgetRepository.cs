using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void LoadBudget(string path)
        {
            string line;
            int curserIncomeCount = 0;
            
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int count = 2;
                    
                    Console.Clear();
                    Console.WriteLine("Budget: ");
                    Console.WriteLine("");
                    List<string> allLines = new List<string>();
                    List<string> income = new List<string>();
                    List<string> expenses = new List<string>();
                    List<int> incomeAmount = new List<int>();
                    List<int> expensesAmount = new List<int>();
                    //TODO: Don't print row that has a value of 0.

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        if (line == "")
                        {
                            curserIncomeCount = count;
                        }
                        count++;

                        allLines = line.Split(':').ToList();
                          
                        for (int i = 0; i < allLines.Count(); i++)
                        {                            
                            if (allLines.Count() > 1)
                            {
                                if (curserIncomeCount < allLines.Count())
                                {
                                    income.Add(allLines[i]);
                                    i++;
                                    incomeAmount.Add(int.Parse(allLines[i]));
                                }
                                if (curserIncomeCount >= allLines.Count())
                                {
                                    expenses.Add(allLines[i]);
                                    i++;
                                    expensesAmount.Add(int.Parse(allLines[i]));
                                }
                            }                                                                                           
                        }                                                                       
                    }
                    Console.WriteLine("\nVil du redigere i dette budget? Y/N");
                    if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                    {
                        Console.Clear();
                        Template template = new Template();
                        template.ExtraIncome();                        
                        template.ExtraExpense();
                        for (int i = 0; i < income.Count; i++)
                        {
                            template.incomeColumn.Add(income[i]);
                            template.Income.Add(incomeAmount[i]);
                        }
                        for (int i = 0; i < expenses.Count; i++)
                        {
                            template.expenseColumn.Add(expenses[i]);
                            template.Expenses.Add(expensesAmount[i]);
                        }
                        template.SaveBudget();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nUgyldigt budgetnavn.");
            }

        }
    }
}
