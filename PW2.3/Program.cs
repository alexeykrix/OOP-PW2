using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LambdaGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("data.json");

            Product[] products = JsonSerializer.Deserialize<Product[]>(json);

            var productsByCategory = products.GroupBy(p => p.Category);

            foreach (var group in productsByCategory)
            {
                Console.WriteLine("Category: " + group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine("- " + product.Name);
                }

                Console.WriteLine();
            }

            var productsByPriceRange = products
                .GroupBy(p =>
                {
                    if (p.Price < 50)
                    {
                        return "Low (<50)";
                    }
                    else if (p.Price < 100)
                    {
                        return "Medium (<100)";
                    }
                    else
                    {
                        return "High (>100)";
                    }
                });

            foreach (var group in productsByPriceRange)
            {
                Console.WriteLine("Price Range: " + group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine("- " + product.Name);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}