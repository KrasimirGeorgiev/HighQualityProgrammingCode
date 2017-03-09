namespace BuilderPatternExample
{
    public class TV_Builder
    {
        public TV BuildCheapTV()
        {
            var cheapTB = new TV();
            cheapTB.ControlBoard = new CheapBoard();
            cheapTB.DisplayMatrix = new CheapMatrix();
            cheapTB.Remote = new SmallRemote();

            return cheapTB;
        }

        public TV BuildDeluxeTV()
        {
            var deluxeTV = new TV();
            deluxeTV.ControlBoard = new DeluxeBoard();
            deluxeTV.DisplayMatrix = new DeluxeMatrix();
            deluxeTV.Remote = new BigRemote();

            return deluxeTV;
        }
    }
}
