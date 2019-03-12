using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Application
{
    public class Controller
    {
        private Controller _instance;

        public Controller Instance => _instance ?? (_instance = new Controller());

        private Controller()
        {

        }
    }
}
