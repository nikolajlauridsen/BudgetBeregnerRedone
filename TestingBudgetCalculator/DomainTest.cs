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

            testBudget.AddIncome("lommepenge",100);
            testBudget.AddIncome("løn", 1800);
            testBudget.AddIncome("mor støtte", 100);

            testBudget.AddExpense("husleje", 500);
            testBudget.AddExpense("mad", 200);
            testBudget.AddExpense("telefon", 100);

            Assert.AreEqual(1200, testBudget.CalculateDisposableIncome());
        }
    }
}
