using System;
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
        // GET: api/HairServicesd
        public HairServiceNode Get()
        {
            // Define node for export
            HairServiceNode node = new HairServiceNode();   

            // Wipe state list
            StatusAdapter.Clear();
            // Execute Adapter method
            HairService[] hairServices = HairServicesAdapter.GetAll();
            // Define data and state to node 
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

            // Export node to JSON
            return node;
        }

        // GET: api/HairServices/5
        public HairServiceNode Get(int id)
        {
            // Define node for export
            HairServiceNode node = new HairServiceNode();
            // Wipe state list
            StatusAdapter.Clear();
            // Execute Adapter method
            HairService[] hairServices = HairServicesAdapter.GetItem(id);
            // Define data and state to node
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

            // Export node to JSON
            return node;
        }

        // POST: api/HairServices
        public HairServiceNode Post([FromBody] HairService hairService)
        {
            // Define node for export
            HairServiceNode node = new HairServiceNode();
            // Wipe state list
            StatusAdapter.Clear();
            // Assign id for hairService
            hairService.IdSvc = HairServicesAdapter.GetCurrentId() + 1;
            try
            {
                // Execute Adapter method
                string rows_affected = HairServicesAdapter.InsertData(hairService);
                // Define data and state to node
                HairService[] addedService = HairServicesAdapter.GetItem(hairService.IdSvc);
                StatusAdapter.AddItem(new NonQuery(200, rows_affected, true));
                node.HairServices = addedService;
                node.State = StatusAdapter.CurrentStatus;

                // Export node to JSON
                return node;
            }
            catch (Exception ex)
            {
                // Define state to Node
                StatusAdapter.AddItem(new NonQuery(500, ex.Message, false));
                node.State = StatusAdapter.CurrentStatus;

                // Export node to JSON 
                return node;
            }
        }

        // PUT: api/HairServices/5
        public void Put(int id, [FromBody] HairService hairService)
        {

        }

        // DELETE: api/HairServices/5
        public void Delete(int id)
        {

        }
    }
}
