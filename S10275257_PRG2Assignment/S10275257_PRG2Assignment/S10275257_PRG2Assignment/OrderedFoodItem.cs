//==========================================================
// Student Number : S10275257
// Student Name : Suhailah Mohd Sani
// Partner Name : Sherlyn Yeo
//==========================================================

namespace Gruberoo
{
    class OrderedFoodItem : FoodItem
    {
        private int qtyOrdered;
        private double subTotal;

        public int QtyOrdered { get; set; }

        public double SubTotal { get; set; }


        public OrderedFoodItem() : base()
        {
            QtyOrdered = 1;
        }

        public OrderedFoodItem(FoodItem item, int qty)
            : base(item.ItemName, item.ItemDesc, item.ItemPrice, item.Customise)
        {
            QtyOrdered = qty;
            CalculateSubtotal();
        }

        public double CalculateSubtotal()
        {
            SubTotal = ItemPrice * QtyOrdered;
            return SubTotal;
        }

        public override string ToString()
        {
            return $"{ItemName} x{QtyOrdered} = ${CalculateSubtotal():0.00}";
        }
    }
}