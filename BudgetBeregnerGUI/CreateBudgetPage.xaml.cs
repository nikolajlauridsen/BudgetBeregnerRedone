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

namespace BudgetBeregnerGUI
{
    /// <summary>
    /// Interaction logic for CreateBudgetPage.xaml
    /// </summary>
    public partial class CreateBudgetPage : Page
    {
        private string[] _clearables = new[] {"Navn", "Mængde", "Budget navn"};
        public CreateBudgetPage(RoutedEventHandler backHandler)
        {
            InitializeComponent();
            BackBtnShowBudget.Click += backHandler;

            AddIncomeName.GotFocus += ClearTextbox;
            AddIncomeAmount.GotFocus += ClearTextbox;

            AddExpenseName.GotFocus += ClearTextbox;
            AddExpenseAmount.GotFocus += ClearTextbox;

            AddBudgetName.GotFocus += ClearTextbox;
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            IncomeList.Items.Add(new MyItems {Name = AddIncomeName.Text, Amount = AddIncomeAmount.Text});

        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            ExpenseList.Items.Add(new MyItems { Name = AddExpenseName.Text, Amount = AddExpenseAmount.Text });
        }

        private void AddBtnShowBudget_Click(object sender, RoutedEventArgs e)
        {
            List<KeyValuePair<string, double>> incomes = new List<KeyValuePair<string, double>>();
            List<KeyValuePair<string, double>> expenses = new List<KeyValuePair<string, double>>();

            foreach (MyItems item in IncomeList.Items)
            {
                double val = Double.Parse(item.Amount);
                incomes.Add(new KeyValuePair<string, double>(item.Name, val));
            }

            foreach (MyItems item in ExpenseList.Items) {
                double val = Double.Parse(item.Amount);
                expenses.Add(new KeyValuePair<string, double>(item.Name, val));
            }

            Controller.Instance.SaveBudget(AddBudgetName.Text, incomes, expenses);
        }

        private void ClearTextbox(object sender, EventArgs e)
        {
            if (sender is TextBox box)
            {
                if (_clearables.Contains(box.Text))
                {
                    box.Text = "";
                }
            }
        }

        private class MyItems
        {
            /*
             * Weird fact of the day.
             * Attributes MUST be declared with { get; set}
             * Even though public attributes defaults to having 
             */
            public string Name { get; set; }
            public string Amount { get; set; }
        }


    }



}
