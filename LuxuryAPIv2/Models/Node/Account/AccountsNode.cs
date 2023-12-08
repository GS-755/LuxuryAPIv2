using LuxuryAPIv2.Models.Account;
using LuxuryAPIv2.Models.Status;
using System.Collections.Generic;

namespace LuxuryAPIv2.Models.Node.Account
{
    public class AccountsNode
    {
        public AccountsNode()
        {
            this.Accounts = null;
            this.State = null;
        }

        public IEnumerable<Accounts> Accounts { get; set; }
        public NonQuery[] State { get; set; }
    }
}