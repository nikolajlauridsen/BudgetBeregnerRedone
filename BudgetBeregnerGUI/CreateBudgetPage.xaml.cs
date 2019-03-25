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
        private string _nameString = "Navn";
        private string _amountString = "Mængde";
        private string _budgetString = "Budget navn";

        private RoutedEventHandler _back;
        private RoutedEventHandler _listUpdater;

        public CreateBudgetPage(RoutedEventHandler backHandler, RoutedEventHandler listUpdater)
        {
            InitializeComponent();
            BackBtnShowBudget.Click += backHandler;
            _back = backHandler;
            _listUpdater = listUpdater;

            AddIncomeName.GotFocus += ClearTextbox;
            AddIncomeName.LostFocus += NameLostFocus;
            AddIncomeAmount.GotFocus += ClearTextbox;
            AddIncomeAmount.LostFocus += AmountLostFocus;

            AddExpenseName.GotFocus += ClearTextbox;
            AddExpenseName.LostFocus += NameLostFocus;
            AddExpenseAmount.GotFocus += ClearTextbox;
            AddExpenseAmount.LostFocus += AmountLostFocus;

            AddBudgetName.GotFocus += ClearTextbox;
            AddBudgetName.LostFocus += BudgetNameLostFocus;
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            if (AddIncomeName.Text.Length < 1 || AddIncomeAmount.Text.Length < 1) return;

            IncomeList.Items.Add(new MyItems {Name = AddIncomeName.Text, Amount = AddIncomeAmount.Text});
            AddIncomeName.Text = _nameString;
            AddIncomeAmount.Text = _amountString;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            if (AddExpenseName.Text.Length < 1 || AddExpenseAmount.Text.Length < 1) return;

            ExpenseList.Items.Add(new MyItems { Name = AddExpenseName.Text, Amount = AddExpenseAmount.Text });
            AddExpenseName.Text = _nameString;
            AddExpenseAmount.Text = _amountString;
        }

        private void AddBtnShowBudget_Click(object sender, RoutedEventArgs e)
        {
            if (IncomeList.Items.Count < 1 && ExpenseList.Items.Count < 1)
            {
                MessageBox.Show("Tilføj venligst indtægter og udgifter inden du gemmer budgettet.");
                return;
            }

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
            _listUpdater(this, null);
            _back(this, null);
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

        private void NameLostFocus(object sender, EventArgs e)
        {
            if (sender is TextBox box)
            {
                if (box.Text.Length < 1) box.Text = _nameString;
            }
        }

        private void AmountLostFocus(object sender, EventArgs e)
        {
            if (sender is TextBox box) {
                if (box.Text.Length < 1) box.Text = _amountString;
            }
        }

        private void BudgetNameLostFocus(object sender, EventArgs e)
        {
            if (sender is TextBox box)
            {
                if (box.Text.Length < 1) box.Text = _budgetString;
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


        private void RemoveIncome_Click(object sender, RoutedEventArgs e)
        {
            IncomeList.Items.Remove(IncomeList.SelectedItem);
        }

        private void RemoveExpense_Click(object sender, RoutedEventArgs e)
        {
            ExpenseList.Items.Remove(ExpenseList.SelectedItem);
        }
    }



}
