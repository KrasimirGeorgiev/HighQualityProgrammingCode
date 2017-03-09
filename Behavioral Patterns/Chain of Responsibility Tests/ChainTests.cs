namespace ChainOfResponsibility.Tests
{
    using System;
    using System.Collections.Generic;
    using ChainOfResponsibility.Storages;
    using ChainOfResponsibility.Requests;
    using HomeworkHelpers;

    class ChainTests
    {
        static TextHelper helper = new TextHelper();

        static void Main()
        {
            var storages = new Queue<IHandle>();
            storages.Enqueue(new TownStorage());
            storages.Enqueue(new CityStorage());
            storages.Enqueue(new ChinaStorage());

            var agent = new StorageAgent(storages);

            var allTheThings = new List<object>()
            {
                new { Phone = "EyePhone", Price = "1000lv." },
                new { Phone = "EyePhone", Price = "899lv." },
                new { Peralnya = "Gnusmas", Price = "500lv." },
                new { Peralnya = "Gnusmas", Price = "600lv." },
                new { Teniska = "68 Brigada", Price = "10lv." }
            };

            helper.PrintColorText("Adding Stock...\n\n", "cyan");

            foreach (var thing in allTheThings)
            {
                Console.WriteLine(
                    agent.Handle(thing, RequestType.Add));
            }

            helper.PrintColorText("\nIs there a cheap EyePhone around?\n\n", "green");
            Console.WriteLine(agent.Handle(new { Phone = "EyePhone", Price = "1000lv." }, RequestType.Check));

            helper.PrintColorText("\nBuy me a peralnya for 500lv.\n\n", "green");
            Console.WriteLine(agent.Handle(new { Peralnya = "Gnusmas", Price = "500lv." }, RequestType.Buy));

            helper.PrintColorText("\nBuy me aonther one\n\n", "red");
            Console.WriteLine(agent.Handle(new { Peralnya = "Gnusmas", Price = "500lv." }, RequestType.Buy));
        }
    }
}
