namespace ObjectPoolExample
{
    using System;

    public class ProgramEntry
    {
        private static void Main()
        {
            var clientsCar = new Car();

            var mitko = new Client("Mitko", clientsCar);
            var jorko = new Client("Jorko", clientsCar);
            var milka = new Client("Milka", clientsCar); 

            var mallOfFood = new HyperMarket(100);

            string freeCartsMsg = "Free carts at the moment: {0}";

            Console.WriteLine(freeCartsMsg, mallOfFood.CartsPool.NumberOfCartsInPool);

            mitko.AskForCart(mallOfFood);
            jorko.AskForCart(mallOfFood);

            mitko.ShoppingCart.AddGroceries(mallOfFood, 5);
            jorko.ShoppingCart.AddGroceries(mallOfFood, 10);

            mitko.Car.FillTrunkWithGroceries(mitko.ShoppingCart);
            jorko.Car.FillTrunkWithGroceries(jorko.ShoppingCart);

            mitko.ReturnCart(mallOfFood);
            jorko.ReturnCart(mallOfFood);

            Console.WriteLine(freeCartsMsg, mallOfFood.CartsPool.NumberOfCartsInPool);

            milka.AskForCart(mallOfFood);

            Console.WriteLine(freeCartsMsg, mallOfFood.CartsPool.NumberOfCartsInPool);

            milka.ShoppingCart.AddGroceries(mallOfFood, 6);
            milka.ReturnCart(mallOfFood);

            Console.WriteLine("Have a nice day");
        }
    }
}
