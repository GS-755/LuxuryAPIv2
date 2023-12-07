using System.Web.Http;
using LuxuryAPIv2.Models;
using LuxuryAPIv2.Adapters;
using LuxuryAPIv2.Models.Node;
using LuxuryAPIv2.Models.Status;
using LuxuryAPIv2.Adapters.Status;

namespace LuxuryAPIv2.Controllers
{
    public class HairServicesController : ApiController
    {
        // GET: api/HairServices
        public HairServiceNode Get()
        {
            HairServiceNode node = new HairServiceNode();   

            StatusAdapter.Clear();
            HairService[] hairServices = HairServicesAdapter.GetAll();
            if (hairServices == null)
            {
                node.State = new NonQuery[] 
                { 
                    new NonQuery(204, "No content", false) 
                };
            }
            else
            {
                node.State = new NonQuery[]
                {
                    new NonQuery(200, "GET Ok", true)
                };
                node.HairServices = hairServices;
            }

            return node;
        }

        // GET: api/HairServices/5
        public HairServiceNode Get(int id)
        {
            HairServiceNode node = new HairServiceNode();

            StatusAdapter.Clear();
            HairService[] hairServices = HairServicesAdapter.GetItem(id);
            if (hairServices == null)
            {
                node.State = new NonQuery[]
                {
                    new NonQuery(404, "Not found", false)
                };
            }
            else
            {
                node.State = new NonQuery[]
                {
                    new NonQuery(200, "GET Ok", true)
                };
                node.HairServices = hairServices;
            }

            return node;
        }

        // POST: api/HairServices
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HairServices/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HairServices/5
        public void Delete(int id)
        {
        }
    }
}
