namespace Strategy
{
    using System;

    public class FuelSaveEconomy : FuelEconomy
    {
        public override void CalculateRoute()
        {
            text.PrintColorText("Calculating fuel conscious route\n", ConsoleColor.DarkGreen);
            this.NecessaryFuel = 4.5;
            this.Route = "Some ordinary route";
            this.TimeNeeded = 2.5;
        }
    }
}