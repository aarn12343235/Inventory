using System;
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

            while (continueShopping)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Grocery Store!");
                Console.WriteLine("-----------------------------");

                
                Console.WriteLine("Available Products:");
                Console.WriteLine($"1. {apple.Name} - ${apple.Price:F2}");
                Console.WriteLine($"2. {brush.Name} - ${brush.Price:F2}");
                Console.WriteLine($"3. {mirror.Name} - ${mirror.Price:F2}");
                Console.WriteLine($"4. {pen.Name} - ${pen.Price:F2}");
                Console.WriteLine($"5. {bag.Name} - ${bag.Price:F2}");

               
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

                
                double partialTotal = 0;
                foreach (Product product in cart)
                {
                    partialTotal += product.Price;
                }
                Console.WriteLine($"Partial Total: ${partialTotal:F2}");

                
                Console.Write("Do you want to add another item? (yes/no): ");
                string response = Console.ReadLine().ToLower();

                if (response != "yes")
                {
                    continueShopping = false;
                }
            }

            
            double totalBeforeDiscount = 0;
            foreach (Product product in cart)
            {
                totalBeforeDiscount += product.Price;
            }

            
            double discount = 0;
            if (totalBeforeDiscount > 500)
            
                discount = totalBeforeDiscount * 0.20; // 20% discount
            
            else if (totalBeforeDiscount > 200)
            
                discount = totalBeforeDiscount * 0.15; // 15% discount
            
            else if (totalBeforeDiscount > 100)
            
                discount = totalBeforeDiscount * 0.10; // 10% discount
            

            double finalAmount = totalBeforeDiscount - discount;

            // Display receipt
            Console.Clear();
            Console.WriteLine("Receipt");
            Console.WriteLine("-------");

            

            Console.WriteLine($"Total Before Discount: ${totalBeforeDiscount:F2}");
            Console.WriteLine($"Discount Applied: ${discount:F2}");
            Console.WriteLine($"Final Amount: ${finalAmount:F2}");

            //new purchase or exit
            Console.Write("Do you want to make a new purchase? (yes/no): ");
            string newPurchaseResponse = Console.ReadLine().ToLower();

            if (newPurchaseResponse == "yes")
            
                Main(args); // Restart the application (pwede diay ni Whhahahaha)
            
            else
            
                Console.WriteLine("Thank you for shopping with us! Goodbye!");
            
        }

        // Method to add a product to the cart
        static void AddProductToCart(ArrayList cart, Product product, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                cart.Add(product);
            }
        }
      
    }
}