// Student Number : S10272248G
// Student Name : Sherlyn Yeo Cai Yun
// Partner Name : Suhailah 

using System;
using System.Collections.Generic;

namespace Gruberoo
{
    class Menu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public List<FoodItem> FoodItemList { get; private set; } = new List<FoodItem>();
        public Menu() { }

        public Menu(string id, string name)
        {
            MenuId = id;
            MenuName = name;
        }

        public void AddFoodItem(FoodItem fi)
        {
            if (fi != null)
                FoodItemList.Add(fi);
        }

        public bool RemoveFoodItem(FoodItem fi)
        {
            if (fi == null) return false;
            return FoodItemList.Remove(fi);
        }

        public void DisplayFoodItems()
        {
            if (FoodItemList.Count == 0)
            {
                Console.WriteLine("  (No food items)");
                return;
            }

            int i = 1;
            foreach (FoodItem fi in FoodItemList)
            {
                Console.WriteLine($"{i}. {fi}");
                i++;
            }
        }

        public override string ToString()
        {
            return $"Menu: {MenuName} ({MenuId})";
        }
    }
}
