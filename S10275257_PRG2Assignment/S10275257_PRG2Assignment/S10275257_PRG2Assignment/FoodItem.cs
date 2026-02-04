// Student Number : S10272248G
// Student Name : Sherlyn Yeo Cai Yun
// Partner Name : Suhailah 

using System;

namespace Gruberoo
{
    class FoodItem
    {
        private string itemName;
        private string itemDesc;
        private double itemPrice;
        private string customise;

        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public double ItemPrice { get; set; }
        public string Customise { get; set; }

        public FoodItem()
        {
            Customise = "";
        }

        public FoodItem(string name, string desc, double price, string customise = "")
        {
            ItemName = name;
            ItemDesc = desc;
            ItemPrice = price;
            Customise = customise;
        }

        public override string ToString()
        {
            string c = string.IsNullOrWhiteSpace(Customise) ? "" : $" (Custom: {Customise})";
            return $"{ItemName}: {ItemDesc} - ${ItemPrice:0.00}{c}";
        }
    }
}