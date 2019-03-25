using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetLibrary.Model;
using CSVTools;

namespace BudgetLibrary.Application
{
    public static class BudgetExporter
    {
        public static void ExportBudget(IBudget budget, string path)
        {
            Table table = new Table();
            // Add name
            table[1, 1] = budget.Name;

            // Add incomes
            table[1, 3] = "Indtægter";
            for (int i = 0; i < budget.Incomes.Count; i++)
            {
                table[1, 4 + i] = budget.Incomes[i].Name;
                table[2, 4 + i] = budget.Incomes[i].Amount;
            }
           

            // Add expenses
            table[4, 3] = "Udgifter";
            for (int i = 0; i < budget.Expenses.Count; i++) {
                table[4, 4 + i] = budget.Expenses[i].Name;
                table[5, 4 + i] = budget.Expenses[i].Amount;
            }

            // Total income
            table[1, table.Dimensions[1] + 2] = "Totale indtægter";
            table[2, table.Dimensions[1]] = budget.Income;

            // Total expense
            table[4, table.Dimensions[1]] = "Totale udgifter";
            table[5, table.Dimensions[1]] = budget.Expense;

            // Disposable income
            table[1, table.Dimensions[1] + 3] = "Rådighedsbeløb";
            table[2, table.Dimensions[1]] = budget.DisposableIncome;
            
            // Save to file
            table.SaveToFile(path);
        }
    }
}
