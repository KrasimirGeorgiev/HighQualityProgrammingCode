namespace Strategy
{
    using System;

    public class StandardEconomy : FuelEconomy
    {
        public override void CalculateRoute()
        {
            text.PrintColorText("Calculating optimal route\n", ConsoleColor.DarkGreen);
            this.NecessaryFuel = 6;
            this.Route = "Some casual route";
            this.TimeNeeded = 1.5;
        }
    }
}