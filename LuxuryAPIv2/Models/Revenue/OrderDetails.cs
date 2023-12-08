namespace LuxuryAPIv2.Models.Revenue
{
    public class OrderDetails
    {
        public int IDSvc { get; set; }
        public int IDOrder { get; set; }
        public double TotalPrice { get; set; }

        public OrderDetails() { }
        public OrderDetails(int IDSvc, int IDOrder, double TotalPrice)
        {
            this.IDSvc = IDSvc;
            this.IDOrder = IDOrder;
            this.TotalPrice = TotalPrice;
        }
    }
}