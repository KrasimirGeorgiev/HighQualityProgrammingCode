namespace Strategy
{
    using HomeworkHelpers;

    public abstract class FuelEconomy
    {
        protected static TextHelper text = new TextHelper();

        public double NecessaryFuel { get; protected set; }

        public string Route { get; protected set; }

        public double TimeNeeded { get; protected set; }

        public abstract void CalculateRoute();

        public override string ToString()
        {
            return string.Format(
                "Rout: {0}\nTime Needed: {1}h\nFuel: {2}"
                , this.Route, this.TimeNeeded, this.NecessaryFuel);
        }
    }
}
