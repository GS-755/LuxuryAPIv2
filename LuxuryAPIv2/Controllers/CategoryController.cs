using System;
using System.Linq;
using System.Web.Http;
using LuxuryAPIv2.Models;
using LuxuryAPIv2.Adapters;
using LuxuryAPIv2.Models.Status;
using System.Collections.Generic;
using LuxuryAPIv2.Adapters.Status;

namespace LuxuryAPIv2.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public IEnumerable<Category> Get()
        {
            return CategoryAdapter.GetAll();
        }

        // GET: api/Category/5
        public IEnumerable<Category> Get(int id)
        {
            return CategoryAdapter.GetItem(id);
        }

        // POST: api/Category
        [HttpPost]
        public NonQuery[] Post([FromBody] Category category)
        {
            try
            {
                string rows_affected = CategoryAdapter.InsertData(category);

                //Return status into JSON
                StatusAdapter.Clear();
                StatusAdapter.AddItem(new NonQuery(200, rows_affected, true));

                return StatusAdapter.StatusList.ToArray();
            }
            catch(Exception ex)
            {
                StatusAdapter.Clear();
                StatusAdapter.AddItem(new NonQuery(500, ex.Message, false));

                return StatusAdapter.StatusList.ToArray();
            }
        }

        // PUT: api/Category/5
        [HttpPost]
        public NonQuery[] Put(int id, [FromBody] Category category)
        {
            try
            {
                Category findCate = CategoryAdapter.GetAll().FirstOrDefault(k => k.IdCate == id);
                if(findCate != null)
                {
                    string rows_affected = CategoryAdapter.UpdateData(category);
                    //Return status into JSON
                    StatusAdapter.Clear();
                    StatusAdapter.AddItem(new NonQuery(200, rows_affected, true));
                }
                else
                {
                    StatusAdapter.Clear();
                    StatusAdapter.AddItem(new NonQuery(404, "Object not found.", false));
                }

                return StatusAdapter.StatusList.ToArray();
            }
            catch (Exception ex)
            {
                StatusAdapter.Clear();
                StatusAdapter.AddItem(new NonQuery(500, ex.Message, false));

                return StatusAdapter.StatusList.ToArray();
            }
        }

        // DELETE: api/Category/5
        [HttpDelete]
        public NonQuery[] Delete(int id)
        {
            try
            {
                Category findCate = CategoryAdapter.GetAll().FirstOrDefault(k => k.IdCate == id);
                if (findCate != null)
                {
                    string rows_affected = CategoryAdapter.DeleteData(findCate);
                    //Return status into JSON
                    StatusAdapter.Clear();
                    StatusAdapter.AddItem(new NonQuery(200, rows_affected, true));
                }
                else
                {
                    StatusAdapter.Clear();
                    StatusAdapter.AddItem(new NonQuery(404, "Object not found.", false));
                }

                return StatusAdapter.StatusList.ToArray();
            }
            catch (Exception ex)
            {
                StatusAdapter.Clear();
                StatusAdapter.AddItem(new NonQuery(500, ex.Message, false));

                return StatusAdapter.StatusList.ToArray();
            }
        }
    }
}
