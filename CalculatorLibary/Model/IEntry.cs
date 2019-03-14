using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary.Model
{
    public interface IEntry
    {
        string Name { get; }
        double Amount { get; }
        int ID { get; }
    }
}
