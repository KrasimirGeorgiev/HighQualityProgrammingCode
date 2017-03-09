namespace ObjectPoolExample
{
    using System.Collections.Generic;

    public class Car
    { 
        private List<Grocery> trunk;

        public Car()
        {
            this.trunk = new List<Grocery>();
        }

        public void FillTrunkWithGroceries(Cart cart) 
        {
            this.trunk.AddRange(cart.CarriedGoods);
            cart.CarriedGoods.RemoveRange(0, cart.CarriedGoods.Count);
        }
    }
}
