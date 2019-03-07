using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetLibrary;
using Budget_Beregner;

namespace TestingBudgetCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInitialize()
        {
          
        }

        [TestMethod]
        public void CorrectCalculation()
        {
            BudgetRepository budget = new BudgetRepository();
            List<int> income = new List<int>();
            List<int> expenses = new List<int>();

            int money = 0;

            for (int i = 0; i < 6; i++)
            {
                income.Add(money);
                money += 100;
            }

            money = 0;

            for (int i = 0; i < 6; i++)
            {
                expenses.Add(money);
                money += 100;
            }

            Assert.AreEqual(0, budget.CalculateDisposableIncome(income, expenses));
        }
    }
}
