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

       public Budget SaveBudget(string name, List<Entry> incomes, List<Entry> entry)
       {
           throw new NotImplementedException();
       }

       public Budget SaveBudget(List<string> incomeColumn, List<string> expenseColumn, List<int> incomeList, List<int> expensesList)
       {
           throw new NotImplementedException();
       }

       public void DeleteBudget(int id)
       {
            Budget budget = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteBudget", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", budget.ID));
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
