using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCoreAPI.Models;

namespace WebCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("Students")]
        public List<StudentModels> Students()
        {
            var list = new List<StudentModels>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var model = new StudentModels { Id = i + 1, Name = "Student number:" + i };
                    list.Add(model);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
    }
}
