using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Gruberoo
{
    class Program
    {
        static List<Restaurant> restaurantList = new List<Restaurant>();
        static List<Customer> customerList = new List<Customer>();

        static void Main(string[] args)
        {
            LoadRestaurants("restaurants.csv");
            LoadFoodItems("fooditems.csv");
            LoadCustomers("customers.csv");
            LoadOrders("orders.csv");

            Console.WriteLine("Welcome to the Gruberoo Food Delivery System");
            Console.WriteLine($"{restaurantList.Count} restaurants loaded!");
            Console.WriteLine($"{GetTotalFoodItemCount()} food items loaded!");
            Console.WriteLine($"{customerList.Count} customers loaded!");
            Console.WriteLine($"{GetTotalOrderCount()} orders loaded!");

            while (true)
            {
                DisplayMenu();
                int choice = ReadInt("Enter your choice: ");

                if (choice == 1)
                    ListAllRestaurantsAndMenuItems();
                else if (choice == 4)
                    ProcessOrder();
                else if (choice == 0)
                    break;
                else
                    Console.WriteLine("Feature not implemented here.");

                Console.WriteLine();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("===== Gruberoo Food Delivery System =====");
            Console.WriteLine("1. List all restaurants and menu items");
            Console.WriteLine("2. List all orders");
            Console.WriteLine("3. Create a new order");
            Console.WriteLine("4. Process an order");
            Console.WriteLine("5. Modify an existing order");
            Console.WriteLine("6. Delete an existing order");
            Console.WriteLine("0. Exit");
        }

        static void ListAllRestaurantsAndMenuItems()
        {
            foreach (Restaurant r in restaurantList)
            {
                Console.WriteLine($"{r.RestaurantName} ({r.RestaurantId})");
                r.DisplayMenu();
                Console.WriteLine();
            }
        }

        static void ProcessOrder()
        {
            string rid = ReadString("Enter restaurant ID: ");
            Restaurant r = restaurantList.FirstOrDefault(x => x.RestaurantId == rid);
            if (r == null || r.OrderQueue.Count == 0) return;

            while (r.OrderQueue.Count > 0)
            {
                Order o = r.OrderQueue.Peek();
                Console.WriteLine(o);

                foreach (OrderedFoodItem ofi in o.OrderedFoodItemList)
                    Console.WriteLine(ofi);

                Console.WriteLine("1 Accept  2 Deliver  3 Reject  4 Skip  0 Exit");
                int opt = ReadInt("Choose: ");

                if (opt == 0) break;

                if (opt == 1 && o.OrderStatus == "Pending")
                    o.OrderStatus = "Preparing";
                else if (opt == 2 && o.OrderStatus == "Preparing")
                {
                    o.OrderStatus = "Delivered";
                    r.OrderQueue.Dequeue();
                }
                else if (opt == 3 && o.OrderStatus == "Pending")
                {
                    o.OrderStatus = "Rejected";
                    r.OrderQueue.Dequeue();
                    r.RefundStack.Push(o);
                }
                else if (opt == 4)
                {
                    r.OrderQueue.Enqueue(r.OrderQueue.Dequeue());
                }
            }
        }

        static int GetTotalFoodItemCount()
        {
            int total = 0;
            foreach (Restaurant r in restaurantList)
                foreach (Menu m in r.MenuList)
                    total += m.FoodItemList.Count;
            return total;
        }

        static int GetTotalOrderCount()
        {
            int total = 0;
            foreach (Customer c in customerList)
                total += c.OrderList.Count;
            return total;
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int n))
                    return n;
            }
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void LoadRestaurants(string f)
        {
            if (!File.Exists(f)) return;

            foreach (string l in File.ReadAllLines(f).Skip(1))
            {
                string[] p = l.Split(',');
                restaurantList.Add(new Restaurant(p[0], p[1], p[2]));
            }
        }

        static void LoadFoodItems(string f)
        {
            if (!File.Exists(f)) return;

            foreach (string l in File.ReadAllLines(f).Skip(1))
            {
                string[] p = l.Split(',');
                Restaurant r = restaurantList.FirstOrDefault(x => x.RestaurantId == p[0]);
                if (r == null) continue;

                if (r.MenuList.Count == 0)
                    r.MenuList.Add(new Menu("M1", "Main"));

                r.MenuList[0].FoodItemList.Add(
                    new FoodItem(p[1], p[2], double.Parse(p[3]))
                );
            }
        }

        static void LoadCustomers(string f)
        {
            if (!File.Exists(f)) return;

            foreach (string l in File.ReadAllLines(f).Skip(1))
            {
                string[] p = l.Split(',');
                customerList.Add(new Customer(p[1], p[0]));
            }
        }

        static void LoadOrders(string f)
        {
            if (!File.Exists(f)) return;

            foreach (string l in File.ReadAllLines(f).Skip(1))
            {
                string[] p = l.Split(',');
                int id = int.Parse(p[0]);

                Customer c = customerList.FirstOrDefault(x => x.EmailAddress == p[1]);
                Restaurant r = restaurantList.FirstOrDefault(x => x.RestaurantId == p[2]);

                if (c == null || r == null) continue;

                Order o = new Order(id, DateTime.Parse(p[3]), p[4]);
                c.OrderList.Add(o);
                r.OrderQueue.Enqueue(o);
            }
        }
    }
}