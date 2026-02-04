//==========================================================
// Student Number : S10275257
// Student Name : Suhailah Mohd Sani
// Partner Name : Sherlyn Yeo
//==========================================================

namespace Gruberoo
{
    class Customer
    {
        private string emailAddress;
        private string customerName;

        public List<Order> OrderList { get; private set; } = new List<Order>();

        public string EmailAddress { get; set; }
        public string CustomerName { get; set; }

        public Customer() { }

        public Customer(string email, string name)
        {
            EmailAddress = email;
            CustomerName = name;
        }

        public override string ToString()
        {
            return $"{CustomerName} ({EmailAddress})";
        }
    }
}