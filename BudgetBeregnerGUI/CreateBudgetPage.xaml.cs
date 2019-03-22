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

        public CreateBudgetPage(RoutedEventHandler backHandler)
        {
            InitializeComponent();
            BackBtnShowBudget.Click += backHandler;
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
            throw new NotImplementedException();
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
