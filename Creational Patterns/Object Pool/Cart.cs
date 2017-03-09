namespace ObjectPoolExample
{
    using System;
    using System.Collections.Generic;

    public class Cart
    {
        public Cart()
        {
            this.CarriedGoods = new List<Grocery>();
        }

        public List<Grocery> CarriedGoods { get; set; }

        public void AddGroceries(HyperMarket market, int count)
        {
            if (market.Goods.Count == 0)
            {
                throw new ApplicationException("No groceries at the store come back later");
            }

            if (market.Goods.Count < count)
            {
                count = market.Goods.Count;
            }

            for (int i = 0; i < count; i++)
            {
                var currentItem = market.Goods[i];
                this.CarriedGoods.Add(currentItem);
                market.Goods.RemoveAt(i);
            }
        }
    }
}
