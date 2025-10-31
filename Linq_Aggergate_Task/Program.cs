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

        //2.Calculate and display the average order amount for people older than 30.

        // 3. display Minimum order amount  of each  person
        

        // 4. Display Maximum order amount of each person

        //5.  Average order amount of each person
    }


    static void PerformElementOperations(List<Person> people, List<Order> orders)
    {

        //Find and display the single order placed on a specific date(e.g., March 5, 2025).

        //Find and display the first order with an amount greater than 150, or show a message if none exist.
    }

    // 3. Quantifier operators - check if all have orders, any order above 250
    static void PerformQuantifierOperations(List<Person> people, List<Order> orders)
    {
        //Check if all people have placed at least one order.

        //Check if any order has an amount greater than 250.
    }


    static void PerformCollectionConversion(List<Person> people, List<Order> orders)
    {
        //Convert your list of orders into a Dictionary, where:

        //The key is the person’s name.

        //The value is a list of their orders.

        //Display the number of orders each person has.
    }
}

