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

namespace BudgetBeregnerGUI
{

    public partial class MainPage : Page
    {
        private Frame _pageHolder;
        private List<IBudget> budgets = new List<IBudget>();
        public MainPage(Frame pageHolder)
        {
            InitializeComponent();
            _pageHolder = pageHolder;

            RefreshBudgetList();
            
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageHolder.Navigate(new ShowBudgetPage(budgets[BudgetList.SelectedIndex], ShowSelf));
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageHolder.Navigate(new CreateBudgetPage(ShowSelf, UpdateList));
        }

        private void ShowSelf(object sender, RoutedEventArgs e)
        {
            _pageHolder.Navigate(this);
        }

        private void UpdateList(object sender, RoutedEventArgs e)
        {
            RefreshBudgetList();
        }

        private void RefreshBudgetList()
        {
            budgets = Controller.Instance.GetBudgets();
            BudgetList.Items.Clear();
            foreach (IBudget budget in budgets) {
                BudgetList.Items.Add(budget);

            }
        }

    }
}
