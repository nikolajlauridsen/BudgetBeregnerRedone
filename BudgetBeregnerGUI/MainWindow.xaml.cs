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
using System.Data;
using System.Data.SqlClient;
using System.Windows.Threading;

namespace BudgetBeregnerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                PageHolder.Navigate(new MainPage(PageHolder));
            }
            catch (SqlException)
            {
                /*
                 * We have to use the dispatcher since WPF gets confused by the splash screen
                 * as well as opening message boxes in the construction of MainWindow
                 * The dispatcher will wait till the application is idle and then dispatch the event
                 * triggering OnError, which will open the message box alerting the user of the DB error.
                 * Source: https://stackoverflow.com/questions/25064920/message-box-closes-automatically-after-a-brief-delay
                 */
                Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(OnError));
            }
            
            
        }

        private void PageHolder_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void OnError()
        {
            this.Hide();
            if (MessageBox.Show(this, "Kunne ikke forbinde til database, kontakt venligst din IT administrator.",
                    "Database fejl", MessageBoxButton.OK) == MessageBoxResult.OK) {
                this.Close();
            }
        }
    }
}
