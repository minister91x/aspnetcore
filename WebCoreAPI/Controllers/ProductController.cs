using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCoreAPI.Services;

namespace WebCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("ProductInsert")]
        public async Task<ActionResult> ProductInsert()
        {
            for (int i = 1; i < 14; i++)
            {
                var product = new EntitiesFrameWork.Entities.Product
                {
                    TenSP = "iPhone " + i,
                    DonGia = 1000 + i,
                    DonViTinh = "Cái",
                    MaSP = "IPHONE_" + i
                };
                await _productServices.AddProductAsync(product);
            }
            return Ok(1);
        }

        [HttpPost("GetAllProduct")]
        public async Task<ActionResult> GetAll()
        {
            var list = await _productServices.GetAll();

            return Ok(list);
        }

    }
}
