using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetLibrary.Domain;

namespace BudgetLibrary.Persistence
{
   public class SQLConnector : IDB
   {
       private static SQLConnector _instance;

       private readonly string _connectionString;

       public static SQLConnector Instance => _instance ?? (_instance = new SQLConnector());

       private SQLConnector()
       {
           _connectionString = System.IO.File.ReadAllText("connection_info.txt");
        }

        public Budget GetBudget(string name)
       {
           throw new NotImplementedException(); 
       }

       public Budget GetBudget(int id)
       {
           Budget budget = null;   
           using (SqlConnection con = new SqlConnection(_connectionString))
           {
               con.Open();
               using (SqlCommand cmd = new SqlCommand("GetBudget", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("ID", id));
                   SqlDataReader reader = cmd.ExecuteReader();
                   if (reader.HasRows)
                   {
                       while (reader.Read())
                       {
                            budget = new Budget(reader["Name"].ToString(), (int)reader["ID"]);
                       }
                   }
               }
               con.Close();

               con.Open();
               if (budget != null)
               {
                   // Fetch income lines
                   using (SqlCommand cmd = new SqlCommand("GetIncomeLines", con)) {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.Add(new SqlParameter("BudgetID", budget.ID));
                       SqlDataReader reader = cmd.ExecuteReader();
                       if (reader.HasRows)
                       {
                           while (reader.Read())
                           {
                               budget.AddIncome(reader["Name"].ToString(), Convert.ToDouble(reader["Amount"]), Convert.ToInt32(reader["ID"]));
                           }
                       }
                   }
                   con.Close();
                   con.Open();
                   // Fetch expense lines
                   using (SqlCommand cmd = new SqlCommand("GetExpenseLines", con)) {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.Add(new SqlParameter("BudgetID", budget.ID));
                       SqlDataReader reader = cmd.ExecuteReader();
                       if (reader.HasRows) {
                           while (reader.Read()) {
                               budget.AddExpense(reader["Name"].ToString(), Convert.ToDouble(reader["Amount"]), Convert.ToInt32(reader["ID"]));
                           }
                       }
                   }
                }
               con.Close();
           }

           return budget;
       }

       public Budget SaveBudget(string name, List<Income> incomes, List<Expense> expenses)
       {
           Budget returnBudget = null;
           using (SqlConnection con = new SqlConnection(_connectionString))
           {            
               con.Open();
               using (SqlCommand cmd = new SqlCommand("InsertBudget",con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("Name", name));
                   SqlDataReader reader = cmd.ExecuteReader();
                   if (reader.HasRows)
                   {
                       reader.Read();
                       int id = Convert.ToInt32(reader[0]);
                       returnBudget = new Budget(name, id);
                   }
               }
               con.Close();
               foreach (Entry income in incomes)
               {
                   con.Open();
                   using (SqlCommand cmd = new SqlCommand("InsertIncome", con))
                   {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.Add(new SqlParameter("Name", income.Name));
                       cmd.Parameters.Add(new SqlParameter("Amount", income.Amount));
                       cmd.Parameters.Add(new SqlParameter("BudgetID", returnBudget.ID));
                       SqlDataReader reader = cmd.ExecuteReader();
                       if (reader.HasRows) {
                           reader.Read();
                           int id = Convert.ToInt32(reader[0]);
                           returnBudget.Incomes.Add(new Income(income.Name, income.Amount, id));
                       }
                    }
                   con.Close();
               }

               con.Close();
               foreach (Entry expense in expenses) {
                   con.Open();
                   using (SqlCommand cmd = new SqlCommand("InsertExpense", con)) {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.Add(new SqlParameter("Name", expense.Name));
                       cmd.Parameters.Add(new SqlParameter("Amount", expense.Amount));
                       cmd.Parameters.Add(new SqlParameter("BudgetID", returnBudget.ID));
                        SqlDataReader reader = cmd.ExecuteReader();
                       if (reader.HasRows) {
                           reader.Read();
                           int id = Convert.ToInt32(reader[0]);
                           returnBudget.Expenses.Add(new Expense(expense.Name, expense.Amount, id));
                       }
                   }
                   con.Close();
               }

            }

            return returnBudget;
       }

       public Budget SaveBudget(List<string> incomeColumn, List<string> expenseColumn, List<int> incomeList, List<int> expensesList)
       {
           throw new NotImplementedException();
       }

       public void DeleteBudget(int id)
       {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("RemoveBudget", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", id));
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
            

       }

        public List<Budget> GetBudgets()
        {

            List<Budget> budgets = new List<Budget>();

            //Adds budgets to a list
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetBudgets", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            budgets.Add(new Budget(reader["Name"].ToString() ,Convert.ToInt32(reader["ID"])));
               
                        }
                    }

                }
                con.Close();

                //Adds IncomeLines to budget
                foreach (Budget budget in budgets)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetIncomeLines", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("ID", budget.ID));
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                budget.AddIncome(reader["Name"].ToString(), Convert.ToDouble(reader["Amount"]), Convert.ToInt32(reader["ID"]));

                            }
                        }

                    }
                    con.Close();
                }

                //Adds expense lines to budget
                foreach (Budget budget in budgets)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetExpenseLines", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("ID", budget.ID));
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                budget.AddExpense(reader["Name"].ToString(), Convert.ToDouble(reader["Amount"]), Convert.ToInt32(reader["ID"]));

                            }
                        }

                    }
                    con.Close();
                }

            }

            return budgets;
        }
    }
}
