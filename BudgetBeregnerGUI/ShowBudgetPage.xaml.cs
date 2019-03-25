using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BudgetLibrary.Application;
using BudgetLibrary.Model;
using Microsoft.Win32;

namespace BudgetBeregnerGUI
{
    /// <summary>
    /// Interaction logic for ShowBudgetPage.xaml
    /// </summary>
    public partial class ShowBudgetPage : Page
    {

        private IBudget _targetBudget;

        public ShowBudgetPage(IBudget budget, RoutedEventHandler handler)
        {
            InitializeComponent();

            _targetBudget = budget;

            BackBtnShowBudget.Click += handler;
            ExportBtn.Click += ExportBudget;

            foreach (IEntry expense in budget.Expenses)
            {
                ExpenseList.Items.Add(expense);
            }

            foreach (IEntry income in budget.Incomes)
            {
                IncomeList.Items.Add(income);
            }

            TotalExpense.Content = budget.Expense;
            TotalIncome.Content = budget.Income;
            DispIncome.Content = budget.DisposableIncome;
        }


        private void ExportBudget(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV file (*.csv)|.csv";
            dialog.ValidateNames = true;
            if (dialog.ShowDialog() == true)
            {
                BudgetExporter.ExportBudget(_targetBudget, dialog.FileName);
            }
        }


    }
}
