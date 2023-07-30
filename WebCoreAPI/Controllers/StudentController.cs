using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebCoreAPI.Models;

namespace WebCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IClassB _iclassB;
        public StudentController(IClassB iclassB)
        {
            _iclassB = iclassB;
        }

        [HttpPost("CongHaiSo")]
        public async Task<int> CongHaiSo(CongHaiSoRequestData requestData)
        {
            var result = await _iclassB.CongHaiSo(requestData.FirstNumber, requestData.LastNumber);
            return result;
        }


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
