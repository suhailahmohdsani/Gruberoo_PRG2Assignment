//==========================================================
// Student Number : S10275257
// Student Name : Suhailah Mohd Sani
// Partner Name : Sherlyn Yeo
//==========================================================

namespace Gruberoo
{
    class SpecialOffer
    {
        private string offerCode;
        private string offerDesc;
        private double discount;

        public string OfferCode { get; set; }
        public string OfferDesc { get; set; }
        public double Discount { get; set; }

        public SpecialOffer() { }

        public SpecialOffer(string code, string desc, double discount)
        {
            OfferCode = code;
            OfferDesc = desc;
            Discount = discount;
        }

        public override string ToString()
        {
            return $"{OfferCode} - {OfferDesc} ({Discount}% off)";
        }
    }
}