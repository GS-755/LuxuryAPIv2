using LuxuryAPIv2.Models.Account;
using LuxuryAPIv2.Models.Status;
using System.Collections.Generic;

namespace LuxuryAPIv2.Models.Node.Account
{
    public class RoleNode
    {
        public RoleNode()
        {
            this.Role = null;
            this.State = null;
        }

        public IEnumerable<Role> Role { get; set; }
        public NonQuery[] State { get; set; }
    }
}