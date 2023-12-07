using LuxuryAPIv2.Models.Status;
using System.Collections.Generic;

namespace LuxuryAPIv2.Models.Node
{
    public class HairServiceNode
    {
        public HairServiceNode() 
        {
            this.HairServices = null;
            this.State = null;
        }

        public IEnumerable<HairService> HairServices { get; set; }
        public NonQuery[] State { get; set; }
    }
}