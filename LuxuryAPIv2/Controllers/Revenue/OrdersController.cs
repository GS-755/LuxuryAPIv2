using System.Web.Http;
using System.Collections.Generic;
using LuxuryAPIv2.Models.Revenue;

namespace LuxuryAPIv2.Controllers.Revenue
{
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Orders/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] Orders order)
        {

        }

        // PUT: api/Orders/5
        [HttpPost]
        public void Put(int id, [FromBody] Orders order)
        {

        }
    }
}
