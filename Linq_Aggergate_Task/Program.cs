using Linq_Aggergate_Task.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
    {
        // Two lists of models
        List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "Alice", Age = 30, Email = "alice@example.com" },
            new Person { Id = 2, Name = "Bob", Age = 25, Email = "" },
            new Person { Id = 3, Name = "Charlie", Age = 35, Email = "charlie@example.com" },
            new Person { Id = 4, Name = "Diana", Age = 40, Email = "diana@example.com" }
        };

        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, PersonId = 1, Amount = 100, OrderDate = new DateTime(2025, 1, 15) },
            new Order { OrderId = 2, PersonId = 2, Amount = 50, OrderDate = new DateTime(2025, 2, 20) },
            new Order { OrderId = 3, PersonId = 1, Amount = 75, OrderDate = new DateTime(2025, 3, 5) },
            new Order { OrderId = 4, PersonId = 3, Amount = 120, OrderDate = new DateTime(2025, 3, 15) },
            new Order { OrderId = 5, PersonId = 4, Amount = 200, OrderDate = new DateTime(2025, 4, 10) }
        };

       
        Console.WriteLine("Aggregation:");
        PerformAggregation(people, orders);

        Console.WriteLine("\nElement Operators:");
        PerformElementOperations(people, orders);

        Console.WriteLine("\nQuantifier Operators:");
        PerformQuantifierOperations(people, orders);

        Console.WriteLine("\nConverting Collections:");
        PerformCollectionConversion(people, orders);

    }

    
    static void PerformAggregation(List<Person> people, List<Order> orders)
    {
        //1.Display the total number of orders and sum of order amounts for each person.

        var orderSummary = orders
                .GroupBy(o => o.PersonId)
                .Select(g => new
                {
                    PersonId = g.Key,
                    TotalOrders = g.Count(),
                    TotalAmount = g.Sum(o => o.Amount)
                });
        Console.WriteLine("The total number of orders and sum of order amounts for each person are:");
        Console.WriteLine("PersonId\tTotalOrders\tTotalAmount");
        foreach(var summary in orderSummary)
        {
            Console.WriteLine(summary.PersonId+"\t\t"+summary.TotalOrders+"\t\t"+summary.TotalAmount);

        }
        Console.WriteLine();


        //2.Calculate and display the average order amount for people older than 30.
        var peopewith30=orders.Join(people.Where(p => p.Age > 30),o=> o.PersonId, p=>p.Id,(o,p)=>o.Amount).Average();
        Console.WriteLine("The average order amount for people older than 30");
        Console.WriteLine(peopewith30);
        Console.WriteLine();

        var minorderamt = orders.GroupBy(p => p.PersonId).Select(g => (
        new { PersonId = g.Key, amt = g.Min(x => x.Amount) }));
        Console.WriteLine("Minimum Order Amount of each person is");
        Console.WriteLine("PersonId\tTotalAmount");
        foreach (var summary in minorderamt)
        {
            Console.WriteLine(summary.PersonId + "\t\t" + summary.amt);

        }
        Console.WriteLine();

        // 4. Display Maximum order amount of each person

         var maxorderamt=orders.GroupBy(o=>o.PersonId).Select(g => (new {PersonID=g.Key, amt = g.Max(x => x.Amount) }));
        Console.WriteLine("Maximun Order Amount of each person is");
        Console.WriteLine("PersonId\tTotalAmount");
        foreach (var summary in minorderamt)
        {
            Console.WriteLine(summary.PersonId + "\t\t" + summary.amt);

        }
        Console.WriteLine();


        //5.  Average order amount of each person
        var avgorderamt=orders.GroupBy(o=>o.PersonId).Select(g=> (new {PersonID=g.Key,avg=g.Average(x => x.Amount) }));
        Console.WriteLine("Average Order Amount of each person is");
        Console.WriteLine("PersonId\tTotalAmount");
        foreach (var summary in minorderamt)
        {
            Console.WriteLine(summary.PersonId + "\t\t" + summary.amt);

        }
        Console.WriteLine();
    }


    static void PerformElementOperations(List<Person> people, List<Order> orders)
    {

        //Find and display the single order placed on a specific date(e.g., March 5, 2025).
        var singleorder = orders.SingleOrDefault(x=>x.OrderDate == new DateTime(2025,3,5));
        Console.WriteLine("the single order placed on a specific date(e.g., March 5, 2025)");
        Console.WriteLine("OrderId");
        Console.WriteLine(singleorder.OrderId);
        Console.WriteLine();

        //Find and display the first order with an amount greater than 150, or show a message if none exist.
        var firstorder = orders.FirstOrDefault(x => x.Amount>150);
        Console.WriteLine("the first order with an amount greater than 150");
        Console.WriteLine("OrderId");
        Console.WriteLine(firstorder.OrderId);
        Console.WriteLine();

    }

    // 3. Quantifier operators - check if all have orders, any order above 250
    static void PerformQuantifierOperations(List<Person> people, List<Order> orders)
    {
        // Check if all people have at least one order
        bool allHaveOrders = people.All(p => orders.Any(o => o.PersonId == p.Id));
        Console.WriteLine("Are all people have at least one order");
        Console.WriteLine(allHaveOrders
            ? "True"
            : "False");

        // Check if any order is greater than 250
        bool anyLargeOrder = orders.Any(o => o.Amount > 250);
        Console.WriteLine("Is  any order is greater than 250");
        Console.WriteLine(anyLargeOrder
            ? "True"
            : "False");
    }



    static void PerformCollectionConversion(List<Person> people, List<Order> orders)
    {
        var orderDictionary = orders
            .Join(people,
                  o => o.PersonId,
                  p => p.Id,
                  (o, p) => new { p.Name, Order = o })
            .GroupBy(x => x.Name)
            .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("Number of orders per person:");
        Console.WriteLine("Person\tOrderCount");

        foreach (var entry in orderDictionary)
        {
            Console.WriteLine($"{entry.Key}\t{entry.Value}");
        }
        Console.WriteLine();
    }

}

