using BudgetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary
{
    public class Template
    {
        public List<string> incomeColumn = new List<string>();
        public List<string> expenseColumn = new List<string>();
        public List<int> Income = new List<int>();
        public List<int> Expenses = new List<int>();
        int row = 0;
        int column = 0;
        int columnAmount = 0;
        int incomeNumber = 0;
        int expenseNumber = 0;


        public void InvalidInputMessage()
        {
            Console.SetCursorPosition(row + 10, column);
            Console.WriteLine("Indtast venligst et tal.");
            Console.SetCursorPosition(row + 35, column);
            Console.ReadKey();
            Console.SetCursorPosition(row + 10, column);
            Console.Write("                                    ");
            Console.SetCursorPosition(row, column);
            Console.Write("                   ");
            Console.SetCursorPosition(row, column);
        }

        public void PrintIncome()
        {
            foreach (string name in incomeColumn)
            {
                Padding(name);
            }
        }

        public void PrintExpenses()
        {
            foreach (string name in expenseColumn)
            {
                Padding(name);
            }
        }

        public void CalculateBudget()
        {
            BudgetRepository budgetRepo = new BudgetRepository();
            double calculatedBudget = budgetRepo.CalculateDisposableIncome(Income, Expenses);
            Console.WriteLine("\nDit rådighedsbeløb er: " + calculatedBudget);
        }

        public void SaveBudget()
        {
            BudgetRepository budgetRepo = new BudgetRepository();
            Console.WriteLine("Vil du gemme dit budget? Y/N");
            string save = Console.ReadLine();
            if (save is "y" || save is "Y")
            {
                budgetRepo.SaveBudget(incomeColumn, expenseColumn, Income, Expenses);
                Console.ReadKey();
            }
            else if (save is "n" || save is "N")
            {
                Console.WriteLine("Tryk på en knap for at komme tilbage til menuen!");
            }

            incomeColumn.Clear();
            expenseColumn.Clear();
            Income.Clear();
            Expenses.Clear();
            columnAmount = 0;
        }

        public void SaveEditedBudget(List<string> incomeColumn, List<string> expenseColumn, List<int> incomeList, List<int> expensesList)
        {
            BudgetRepository budgetRepo = new BudgetRepository();
            Console.WriteLine("Vil du gemme dit budget? Y/N");
            string save = Console.ReadLine();
            if (save is "y" || save is "Y")
            {
                budgetRepo.SaveBudget(incomeColumn, expenseColumn, incomeList, expensesList);
                Console.ReadKey();
            }
            else if (save is "n" || save is "N")
            {
                Console.WriteLine("Tryk på en knap for at komme tilbage til menuen!");
            }

            incomeColumn.Clear();
            expenseColumn.Clear();
            Income.Clear();
            Expenses.Clear();
            columnAmount = 0;
        }

        public void TemplateSimple()
        {
            row = 30;
            column = 2;
            incomeColumn.Add("SU: ");
            incomeColumn.Add("Løn:");

            expenseColumn.Add("Mobil: ");
            expenseColumn.Add("Husleje: ");
            expenseColumn.Add("Streaming tjenester: ");
            expenseColumn.Add("Opsparing: ");
            columnAmount = (incomeColumn.Count + expenseColumn.Count);
            Console.Clear();
            Console.WriteLine("Budget til 18-25 årige der bor hjemme");
            Padding("Indtast indkomster");

            PrintIncome();
            InputIncome();
            ExtraIncome();

            Padding("Indtast Udgifter");

            PrintExpenses();
            row = 30;
            InputExpense();
            ExtraExpense();

            CalculateBudget();
            SaveBudget();
        }

        public void TemplateAdvanced()
        {
            row = 30;
            column = 2;
            incomeColumn.Add("SU: ");
            incomeColumn.Add("Løn: ");
            incomeColumn.Add("Boligstøtte: ");
            incomeColumn.Add("Stipendier: ");

            expenseColumn.Add("Forsikring: ");
            expenseColumn.Add("Husleje: ");
            expenseColumn.Add("Aconto: ");
            expenseColumn.Add("El: ");
            expenseColumn.Add("A-kasse: ");
            expenseColumn.Add("Mad: ");
            expenseColumn.Add("Mobil: ");
            expenseColumn.Add("Transport: ");
            expenseColumn.Add("Internet/lincens: ");
            expenseColumn.Add("Fitness og sport: ");
            expenseColumn.Add("Streaming tjenester: ");
            expenseColumn.Add("Opsparing: ");

            columnAmount = (incomeColumn.Count + expenseColumn.Count);

            Console.Clear();
            Console.WriteLine("Budget til 18-25 årige der bor ude");
            Console.WriteLine("Indtast indkomster");

            PrintIncome();
            InputIncome();
            ExtraIncome();

            Console.WriteLine("Indtast Udgifter");

            PrintExpenses();
            row = 30;
            InputExpense();
            ExtraExpense();

            CalculateBudget();
            SaveBudget();
        }

        public void TemplatePersonal()
        {
            column = 2;

            Console.Clear();
            Console.WriteLine("Velkommen til dit eget personlige budget!");
            Console.WriteLine("Indtast indkomster, navn og værdi, og afslut med 'ENTER':");

            AddIncome();

            Console.WriteLine("Indtast udgifter, navn og værdi, og afslut med 'ENTER':");

            AddExpense();

            CalculateBudget();
            SaveBudget();
        }

        private void InputIncome()
        {
            for (int i = 0; i < incomeColumn.Count;)
            {
                Console.SetCursorPosition(row, column);
                string input = Console.ReadLine();

                if (int.TryParse(input, out incomeNumber))
                {
                    Income.Add(incomeNumber);
                    column += 1;
                    i++;
                }

                else
                {
                    InvalidInputMessage();
                }
            }
        }

        private void InputExpense()
        {
            for (int i = 0; i < expenseColumn.Count;)
            {
                Console.SetCursorPosition(row, column);
                string input = Console.ReadLine();

                if (int.TryParse(input, out expenseNumber))
                {
                    Expenses.Add(expenseNumber);
                    column += 1;
                    i++;
                }

                else
                {
                    InvalidInputMessage();
                }
            }
        }

        public void AddIncome()
        {
            bool exit = true;
            bool looping = true;
            row = 0;
            Console.SetCursorPosition(row, column);

            while (exit)
            {
                looping = true;
                row = 0;
                Console.SetCursorPosition(row, column);
                Padding("");
                Console.SetCursorPosition(row + 5, column);
                string input = Console.ReadLine();

                // Exits out of income input
                if (input.Equals(string.Empty))
                {
                    exit = false;
                    column += 2;
                }

                else if (input is string)
                {
                    incomeColumn.Add(input);
                    row = 30;

                    while (looping)
                    {
                        Console.SetCursorPosition(row, column);
                        input = Console.ReadLine();

                        if (int.TryParse(input, out incomeNumber))
                        {
                            Income.Add(incomeNumber);
                            column += 1;
                            looping = false;
                        }

                        else
                        {
                            InvalidInputMessage();
                        }
                    }
                }
            }
        }

        public void AddExpense()
        {
            bool exit = true;
            bool looping = true;
            row = 0;
            Console.SetCursorPosition(row, column);

            while (exit)
            {
                looping = true;
                row = 0;
                Console.SetCursorPosition(row, column);
                Padding("");
                Console.SetCursorPosition(row + 5, column);
                string input = Console.ReadLine();

                if (input.Equals(string.Empty))
                {
                    exit = false;
                }

                else if (input is string)
                {
                    expenseColumn.Add(input);
                    row = 30;

                    while (looping)
                    {
                        Console.SetCursorPosition(row, column);
                        input = Console.ReadLine();

                        if (int.TryParse(input, out expenseNumber))
                        {
                            Expenses.Add(expenseNumber);
                            column += 1;
                            looping = false;
                        }

                        else
                        {
                            InvalidInputMessage();
                        }
                    }
                }
            }
        }

        //TODO: Hvis den får andet input end y og n så bliver det helt fucked.
        public void ExtraIncome()
        {
            bool close = true;
            BudgetRepository budgetRepo = new BudgetRepository();
            Console.WriteLine("\nVil du tilføje ekstra indkomster? Y/N");

            while (close)
            {
                Console.SetCursorPosition(0, column + 2);
                Console.WriteLine("        "); 
                Console.SetCursorPosition(0, column + 2);
                string save = Console.ReadLine();

                if (save is "y" || save is "Y")
                {
                    Console.WriteLine("Afslut med 'ENTER'");
                    row = 0;
                    Console.SetCursorPosition(row, column);
                    Console.SetCursorPosition(row = 0, column + 1);
                    Console.WriteLine("                                                           ");
                    Console.WriteLine("                                                           ");
                    Console.WriteLine("                                                           ");
                    AddIncome();
                    Console.SetCursorPosition(row, column - 2);
                    Console.WriteLine("                                                           ");
                    close = false;
                }
                else if (save is "n" || save is "N")
                {
                    Console.SetCursorPosition(row = 0, column + 1);
                    Console.WriteLine("                                                           ");
                    Console.WriteLine("                                                           ");
                    
                    column += 4;
                    close = false;
                }
            }
        }

        public void ExtraExpense()
        {
            bool close = true;
            BudgetRepository budgetRepo = new BudgetRepository();
            Console.WriteLine("\nVil du tilføje ekstra udgifter? Y/N");

            while (close)
            {
                Console.SetCursorPosition(0, column + 2);
                Console.WriteLine("        ");
                Console.SetCursorPosition(0, column + 2);
                string save = Console.ReadLine();

                if (save is "y" || save is "Y")
                {
                    Console.SetCursorPosition(row = 0, column + 1);
                    Console.WriteLine("                                                           ");
                    Console.WriteLine("                                                           ");
                    AddExpense();
                    Console.SetCursorPosition(row, column);
                    Console.WriteLine("                                                           ");
                    column += 1;
                    close = false;
                }

                else if (save is "n" || save is "N")
                {
                    close = false;
                }
            }
        }

        public static void Padding(string mystring)
        {
            Console.WriteLine("  |  " + mystring.PadRight(22, ' ') + "|");
        }
    }
}
