﻿using System;
using System.Collections; 

namespace GroceryStoreDiscountCalculator
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList cart = new ArrayList(); 

            Product apple = new Product("Apple", 1.0);
            Product brush = new Product("Brush", 5.05);
            Product mirror = new Product("Mirror", 3.20);
            Product pen = new Product("Pen", 11.06);
            Product bag = new Product("Bag", 110.08);

            bool continueShopping = true;

            Console.WriteLine("Welcome to the Grocery Store!");
            Console.WriteLine("-----------------------------");

            while (continueShopping)
            {
                
                Console.WriteLine("Available Products:");
                Console.WriteLine($"[1]. {apple.Name} - ${apple.Price:F2}");
                Console.WriteLine($"[2]. {brush.Name} - ${brush.Price:F2}");
                Console.WriteLine($"[3]. {mirror.Name} - ${mirror.Price:F2}");
                Console.WriteLine($"[4]. {pen.Name} - ${pen.Price:F2}");
                Console.WriteLine($"[5]. {bag.Name} - ${bag.Price:F2}");

                Console.Write("Enter the number of the product you want to purchase: ");
                int productChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                switch (productChoice)
                {
                    case 1:
                        AddProductToCart(cart, apple, quantity);
                        break;
                    case 2:
                        AddProductToCart(cart, brush, quantity);
                        break;
                    case 3:
                        AddProductToCart(cart, mirror, quantity);
                        break;
                    case 4:
                        AddProductToCart(cart, pen, quantity);
                        break;
                    case 5:
                        AddProductToCart(cart, bag, quantity);
                        break;
                    default:
                        Console.WriteLine("Invalid product choice. Please try again.");
                        continue;
                }

                
                double partialTotal = CalculateTotal(cart);
                Console.WriteLine($"Partial Total: ${partialTotal:F2}");

                
                Console.Write("Do you want to add another item? (yes/no): ");
                string response = Console.ReadLine().ToLower();

                if (response != "yes")
                    continueShopping = false;
                
            }

            
            double totalBeforeDiscount = CalculateTotal(cart);
            double discount = CalculateDiscount(totalBeforeDiscount);
            double finalAmount = totalBeforeDiscount - discount;

            
            Console.Clear();
            Console.WriteLine("Receipt");
            Console.WriteLine("-------");
            foreach (Product product in cart)
            {
                Console.WriteLine($"{product.Name}: ${product.Price:F2}");
            }

            Console.WriteLine($"Total Before Discount: ${totalBeforeDiscount:F2}");
            Console.WriteLine($"Discount Applied: ${discount:F2}");
            Console.WriteLine($"Final Amount: ${finalAmount:F2}");

            Console.Write("Do you want to make a new purchase? (yes/no): ");
            string newPurchaseResponse = Console.ReadLine().ToLower();

            if (newPurchaseResponse == "yes")
                Main(args); 
           
            else
                Console.WriteLine("Thank you for shopping with us! Goodbye!");
        }

        
        static void AddProductToCart(ArrayList cart, Product product, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                cart.Add(product);
            
        }

        static double CalculateTotal(ArrayList cart)
        {
            double total = 0;
            foreach (Product product in cart)
                total += product.Price;

            return total;
        }

        static double CalculateDiscount(double total)
        {
            if (total > 500)
            
                return total * 0.20; // 20% discount
            
            else if (total > 200)
            
                return total * 0.15; // 15% discount
            
            else if (total > 100)
            
                return total * 0.10; // 10% discount
            
            else
            
                return 0; // No discount
            
        }
    }
}