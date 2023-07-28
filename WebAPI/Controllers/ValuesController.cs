using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public List<StudentModels> Students()
        {
            var list = new List<StudentModels>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var model = new StudentModels { Id= i+1, Name="Student number:"+i };
                    list.Add(model);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
