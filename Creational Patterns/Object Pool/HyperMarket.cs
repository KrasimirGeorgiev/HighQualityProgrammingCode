namespace ObjectPoolExample
{
    using System;
    using System.Collections.Generic;

    public class HyperMarket
    {
        private decimal cash;

        public HyperMarket(int amountOfGroceries)
        {
            this.Goods = new List<Grocery>();

            for (int i = 0; i < amountOfGroceries; i++)
            {
                this.Goods.Add(new Grocery(2));
            }

            this.CartsPool = new CartsPool();
        }

        public List<Grocery> Goods { get; set; }

        public CartsPool CartsPool { get; set; }

        public Cart SellGroceries(decimal money, Cart selectedGroceries)
        {
            decimal bill = 0;

            foreach (var grocery in selectedGroceries.CarriedGoods)
            {
                bill += grocery.Price;
                grocery.IsPaid = true;
            }

            if (bill <= money)
            {
                this.cash += money;
                return selectedGroceries;
            }
            else
            {
                selectedGroceries.CarriedGoods.ForEach(g => g.IsPaid = false);
                throw new ApplicationException("Call the Police!");
            }
        }
    }
}
