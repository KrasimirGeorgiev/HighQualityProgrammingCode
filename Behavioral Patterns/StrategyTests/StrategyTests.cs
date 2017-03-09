namespace Strategy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HomeworkHelpers;

    class StrategyTests
    {
        static TextHelper helper = new TextHelper();

        static void Main()
        {
            helper.SetupConsole();

            var tripComp = new TripComputer();

            tripComp.FuelEconomy = new StandardEconomy();         
            helper.PrintColorText("Loaded Standard Economy\n\n", ConsoleColor.DarkBlue);
            tripComp.FuelEconomy.CalculateRoute();
            PrintFuelEconomy(tripComp.FuelEconomy);

            tripComp.FuelEconomy = new FuelSaveEconomy();           
            helper.PrintColorText("Loaded FuelSave Economy\n\n", ConsoleColor.DarkBlue);
            tripComp.FuelEconomy.CalculateRoute();
            PrintFuelEconomy(tripComp.FuelEconomy);

            tripComp.FuelEconomy = new AggressiveEconomy();
            helper.PrintColorText("Loaded Aggressive Economy\n\n", ConsoleColor.DarkBlue);
            tripComp.FuelEconomy.CalculateRoute();
            PrintFuelEconomy(tripComp.FuelEconomy);
        }

        static void PrintFuelEconomy(FuelEconomy economy)
        {
            
            helper.PrintColorText(economy.ToString(), ConsoleColor.DarkBlue);
            Console.WriteLine();
        }
    }
}
