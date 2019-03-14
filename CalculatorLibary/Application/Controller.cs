using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BudgetLibrary.Domain;
using BudgetLibrary.Model;
using BudgetLibrary.Persistence;

namespace BudgetLibrary.Application
{
    public class Controller
    {
        private Controller _instance;

        public Controller Instance => _instance ?? (_instance = new Controller());

        private Controller()
        {

        }

        public IBudget GetBudget(int id)
        {
            return SQLConnector.Instance.GetBudget(id);
        }

        public List<IBudget> GetBudgets()
        {
            return new List<IBudget>(SQLConnector.Instance.GetBudgets());
        }
    }
}
