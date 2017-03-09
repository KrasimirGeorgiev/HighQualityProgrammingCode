namespace ObjectPoolExample
{
    using System;
    using System.Collections.Generic;

    public class CartsPool
    {
        public const decimal CartTax = 0.50m;

        private List<Cart> freeCarts;

        private decimal collectedTax;

        public CartsPool()
        {
            this.freeCarts = new List<Cart>();
        }

        public int NumberOfCartsInPool
        {
            get
            {
                return this.freeCarts.Count;
            }
        }

        public Cart ReleaseCart(decimal receivedTax)
        {
            if (receivedTax < CartTax)
            {
                throw new ApplicationException("Call the police!");
            }
            else
            {
                this.collectedTax += receivedTax;
            }

            Cart currentCart;

            if (this.freeCarts.Count == 0)
            {
                currentCart = new Cart();
            }
            else
            {
                int lastCart = this.freeCarts.Count - 1;
                currentCart = this.freeCarts[lastCart];
                this.freeCarts.RemoveAt(lastCart);
            }

            return currentCart;
        }

        public decimal AquireCart(Cart returnedCart)
        {
            decimal refundedTax;

            if (returnedCart.CarriedGoods.Count > 0) 
            {
                returnedCart.CarriedGoods.RemoveRange(0, returnedCart.CarriedGoods.Count);

                Console.WriteLine("Shto si ostaviate boklucite vytre!? Globa!");
                refundedTax = CartTax / 2;
            }
            else
            {
                refundedTax = CartTax;
            }

            this.collectedTax -= refundedTax;
            this.freeCarts.Add(returnedCart);

            return refundedTax;
        }
    }
}
