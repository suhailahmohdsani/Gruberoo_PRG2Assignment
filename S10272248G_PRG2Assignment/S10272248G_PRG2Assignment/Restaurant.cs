// Student Number : S10272248G
// Student Name : Sherlyn Yeo Cai Yun
// Partner Name : Suhailah 

using System;
using System.Collections.Generic;

namespace Gruberoo
{
    class Restaurant
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantEmail { get; set; }

        public List<Menu> MenuList { get; private set; } = new List<Menu>();
        public List<SpecialOffer> SpecialOfferList { get; private set; } = new List<SpecialOffer>();
        public Queue<Order> OrderQueue { get; private set; } = new Queue<Order>();
        public Stack<Order> RefundStack { get; private set; } = new Stack<Order>();

        public Restaurant() { }

        public Restaurant(string id, string name, string email)
        {
            RestaurantId = id;
            RestaurantName = name;
            RestaurantEmail = email;
        }

        public void DisplayMenu()
        {
            if (MenuList.Count == 0)
            {
                Console.WriteLine("(No menus)");
                return;
            }

            foreach (Menu m in MenuList)
            {
                Console.WriteLine(m);
                m.DisplayFoodItems();
            }
        }

        public void DisplayOrders()
        {
            if (OrderQueue.Count == 0)
            {
                Console.WriteLine("(No orders)");
                return;
            }

            foreach (Order o in OrderQueue)
            {
                Console.WriteLine(o);
            }
        }

        public void DisplaySpecialOffers()
        {
            if (SpecialOfferList.Count == 0)
            {
                Console.WriteLine("(No offers)");
                return;
            }

            foreach (SpecialOffer so in SpecialOfferList)
            {
                Console.WriteLine(so);
            }
        }

        public override string ToString()
        {
            return $"Restaurant: {RestaurantName} ({RestaurantId})";
        }
    }
}
