using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetLibrary;
using BudgetLibrary.Application;
using BudgetLibrary.Model;

namespace Budget_Beregner
{
    public class Menu
    {
        bool running = true;

        public void StartMenu()
        {
            do
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;                   
                ShowMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        ChooseBudget();
                        break;
                    case "2":
                        BudgetMenu();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");                        
                        Console.ReadKey();
                        break;
                }
            } while (running);
        }

        public void BudgetMenu()
        {
            Template budget = new Template();
            bool menuType = true;
            do
            {
                ShowBudgetMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        ShowMenu();
                        menuType = false;
                        break;
                    case "1":
                        budget.TemplateSimple();
                        break;
                    case "2":
                        budget.TemplateAdvanced();
                        break;
                    case "3":
                        budget.TemplatePersonal();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadKey();
                        break;
                }
            } while (menuType);
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(@"  ____            _            _     _                                         ");
            Console.WriteLine(@" |  _ \          | |          | |   | |                                        ");
            Console.WriteLine(@" | |_) |_   _  __| | __ _  ___| |_  | |__   ___ _ __ ___  __ _ _ __   ___ _ __ ");
            Console.WriteLine(@" |  _ <| | | |/ _` |/ _` |/ _ \ __| | '_ \ / _ \ '__/ _ \/ _` | '_ \ / _ \ '__|");
            Console.WriteLine(@" | |_) | |_| | (_| | (_| |  __/ |_  | |_) |  __/ | |  __/ (_| | | | |  __/ |   ");
            Console.WriteLine(@" |____/ \__,_|\__,_|\__, |\___|\__| |_.__/ \___|_|  \___|\__, |_| |_|\___|_|   ");
            Console.WriteLine(@"                     __/ |                                __/ |                ");
            Console.WriteLine(@"                    |___/                                |___/                 ");


            Console.WriteLine("\n" + "+=======+============================+");
            Console.WriteLine("| Punkt | Vælg venligst et menupunkt |");
            Console.WriteLine("+=======+============================+");
            Console.WriteLine("|   1   | Vis budget                 |");
            Console.WriteLine("+-------+----------------------------+");
            Console.WriteLine("|   2   | Lav budget                 |");
            Console.WriteLine("+-------+----------------------------+");
            Console.WriteLine("|   0   | Exit                       |");
            Console.WriteLine("+-------+----------------------------+");

    //Console.WriteLine("\nVælg venligst en af nedenstående menupunkter:\n");
    //        Console.WriteLine("1. Vis budget.\n");
    //        Console.WriteLine("2. Lav et budget.\n");
    //        Console.WriteLine("0. Exit.\n");
        }
        private void ShowBudgetMenu()
        {
            Console.Clear();
            Console.WriteLine(@"  ____            _            _     _                                         ");
            Console.WriteLine(@" |  _ \          | |          | |   | |                                        ");
            Console.WriteLine(@" | |_) |_   _  __| | __ _  ___| |_  | |__   ___ _ __ ___  __ _ _ __   ___ _ __ ");
            Console.WriteLine(@" |  _ <| | | |/ _` |/ _` |/ _ \ __| | '_ \ / _ \ '__/ _ \/ _` | '_ \ / _ \ '__|");
            Console.WriteLine(@" | |_) | |_| | (_| | (_| |  __/ |_  | |_) |  __/ | |  __/ (_| | | | |  __/ |   ");
            Console.WriteLine(@" |____/ \__,_|\__,_|\__, |\___|\__| |_.__/ \___|_|  \___|\__, |_| |_|\___|_|   ");
            Console.WriteLine(@"                     __/ |                                __/ |                ");
            Console.WriteLine(@"                    |___/                                |___/                 ");
            Console.WriteLine("--== Vælg hvilket budget du vil lægge ==--");
            Console.WriteLine();
            Console.WriteLine("1. Lav simpelt budget - Simpelt budget som er målrettet mod den hjemmeboende studerende i alderen 18-25.\n");
            Console.WriteLine("2. Lav advanceret budget - Advanceret budget som er målrettet mod den udeboende studerende i alderen 18-25.\n");
            Console.WriteLine("3. Lav eget budget - Lav personligt budget med egne indkomster og udgifter.\n");
            Console.WriteLine("0. Gå tilbage til forrige menu.\n");
        }

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
        private void ChooseBudget()
        {
            Console.Clear();
            Console.WriteLine(@"  ____            _            _     _                                         ");
            Console.WriteLine(@" |  _ \          | |          | |   | |                                        ");
            Console.WriteLine(@" | |_) |_   _  __| | __ _  ___| |_  | |__   ___ _ __ ___  __ _ _ __   ___ _ __ ");
            Console.WriteLine(@" |  _ <| | | |/ _` |/ _` |/ _ \ __| | '_ \ / _ \ '__/ _ \/ _` | '_ \ / _ \ '__|");
            Console.WriteLine(@" | |_) | |_| | (_| | (_| |  __/ |_  | |_) |  __/ | |  __/ (_| | | | |  __/ |   ");
            Console.WriteLine(@" |____/ \__,_|\__,_|\__, |\___|\__| |_.__/ \___|_|  \___|\__, |_| |_|\___|_|   ");
            Console.WriteLine(@"                     __/ |                                __/ |                ");
            Console.WriteLine(@"                    |___/                                |___/                 ");

            Console.WriteLine();

            List<IBudget> budgets = Controller.Instance.GetBudgets();

            for (int i = 0; i<budgets.Count; i++)
            {
                Console.WriteLine($"{i+1} {budgets[i].Name}");
            }

            Console.Write("Vælg budget: ");
            int selection;
            if (int.TryParse(Console.ReadLine(), out selection))
            {
                PrintBudget(budgets[selection-1]);
            }
            else
            {
                Console.WriteLine("Please enter a NUMBER");
            }
            Console.ReadKey();
        }

        private void PrintBudget(IBudget budget)
        {
            Console.Clear();
            Console.WriteLine("Indtægter");
            foreach (IEntry income in budget.Incomes) {
                Console.WriteLine($"{income.Name}:\t{income.Amount}");
            }
            Console.WriteLine($"Totale indtægter:\t{budget.Income}\n\n");

            Console.WriteLine("Udgifter");
            foreach (IEntry expense in budget.Expenses) {
                Console.WriteLine($"{expense.Name}:\t{expense.Amount}");
            }
            Console.WriteLine($"Totale udgifter:\t{budget.Expense}\n\n");

            Console.WriteLine($"Rådigheds beløb:\t{budget.DisposableIncome}");
        }


    }
}
