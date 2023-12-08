using LuxuryAPIv2.Models.Revenue;
using LuxuryAPIv2.Models.Status;
using System.Collections.Generic;

namespace LuxuryAPIv2.Models.Node.Revenue
{
    public class OrdersNode
    {
        public OrdersNode()
        {
            this.Orders = null;
            this.State = null;
        }

        public IEnumerable<Orders> Orders { get; set; }
        public NonQuery[] State { get; set; }
    }
}