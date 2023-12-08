using System.Web.Http;
using System.Collections.Generic;
using LuxuryAPIv2.Models.Revenue;

namespace LuxuryAPIv2.Controllers.Revenue
{
    public class OrderDetailsController : ApiController
    {
        // GET: api/OrderDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderDetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderDetails
        [HttpPost]
        public void Post([FromBody] OrderDetails orderDetails)
        {

        }

        // PUT: api/OrderDetails/5
        [HttpPost]
        public void Put(int id, [FromBody] OrderDetails orderDetails)
        {

        }
    }
}
