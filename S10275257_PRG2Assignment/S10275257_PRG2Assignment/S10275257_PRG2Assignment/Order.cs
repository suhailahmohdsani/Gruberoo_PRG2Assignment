//==========================================================
// Student Number : S10275257
// Student Name : Suhailah Mohd Sani
// Partner Name : Sherlyn Yeo
//==========================================================

using System;
using System.Collections.Generic;

namespace Gruberoo
{
    class Order
    {
        private int orderId;
        private DateTime orderDateTime;
        private double orderTotal;
        private string orderStatus;
        private DateTime deliveryDateTime;
        private string deliveryAddress;
        private string orderPaymentMethod;
        private bool orderPaid;

        public List<OrderedFoodItem> OrderedFoodItemList { get; private set; } = new List<OrderedFoodItem>();
        public SpecialOffer AppliedOffer { get; set; }

        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderPaymentMethod { get; set; }
        public bool OrderPaid { get; set; }

        public Order()
        {
            OrderDateTime = DateTime.Now;
            OrderStatus = "Pending";
        }

        public Order(int id, DateTime deliveryDT, string address)
        {
            OrderId = id;
            OrderDateTime = DateTime.Now;
            DeliveryDateTime = deliveryDT;
            DeliveryAddress = address;
            OrderStatus = "Pending";
        }

        public double CalculateOrderTotal()
        {
            double total = 0;

            foreach (OrderedFoodItem ofi in OrderedFoodItemList)
            {
                total += ofi.CalculateSubtotal();
            }

            if (AppliedOffer != null)
            {
                total *= (1 - AppliedOffer.Discount / 100);
            }

            OrderTotal = total;
            return total;
        }

        public override string ToString()
        {
            return $"Order {OrderId} | ${CalculateOrderTotal():0.00} | {OrderStatus}";
        }
    }
}