using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetLibrary.Domain;

namespace TestingBudgetCalculator
{
    [TestClass]
    public class DomainTest
    {
        [TestMethod]
        public void TestDisposableIncome()
        {
            Budget testBudget = new Budget("Test budget");

            testBudget.AddIncome("lommepenge",100, 1);
            testBudget.AddIncome("løn", 1800, 2);
            testBudget.AddIncome("mor støtte", 100, 3);

            testBudget.AddExpense("husleje", 500, 1);
            testBudget.AddExpense("mad", 200, 2);
            testBudget.AddExpense("telefon", 100, 3);

            Assert.AreEqual(1200, testBudget.CalculateDisposableIncome());
        }
    }
}
