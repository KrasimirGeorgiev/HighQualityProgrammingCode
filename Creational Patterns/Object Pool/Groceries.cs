namespace ObjectPoolExample
{
    public class Grocery
    {
        public Grocery(decimal price)
        {
            this.Price = price;
        }

        public decimal Price { get; set; }

        public bool IsPaid { get; set; }
    }
}
