namespace Strategy
{
    using System;

    public class AggressiveEconomy : FuelEconomy
    {
        public override void CalculateRoute()
        {
            text.PrintColorText("Calculating the fastest possible route\n", ConsoleColor.DarkGreen);
            this.NecessaryFuel = 100;
            this.Route = "Fast and Furious 10 route";
            this.TimeNeeded = 0.5;
        }
    }
}