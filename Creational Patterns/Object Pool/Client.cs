namespace ObjectPoolExample
{
    public class Client
    {
        public Client(string name, Car car) 
        {
            this.Name = name;
            this.Car = car;
        }

        public string Name { get; set; }

        public Car Car { get; set; }

        public Cart ShoppingCart { get; set; }

        public void AskForCart(HyperMarket market)
        {
            this.ShoppingCart = market.CartsPool.ReleaseCart(0.50m);
        }

        public void ReturnCart(HyperMarket market)
        {
            market.CartsPool.AquireCart(this.ShoppingCart);
            this.ShoppingCart = null;
        }
    }
}
