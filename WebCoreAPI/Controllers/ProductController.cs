using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebCoreAPI.EntitiesFrameWork.Entities;
using WebCoreAPI.Models;
using WebCoreAPI.Services;
using WebCoreAPI.UnitOfWork;

namespace WebCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        private readonly IMyShopUnitOfWork _myShopUnitOfWork;
        private readonly IConfiguration _configuration;
        public ProductController(IProductServices productServices,
            IMyShopUnitOfWork myShopUnitOfWork,
            IConfiguration configuration)
        {
            _productServices = productServices;
            _myShopUnitOfWork = myShopUnitOfWork;
            _configuration = configuration;
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

            var currentUser = GetCurrentUser();
            if (currentUser == null || currentUser.Id <= 0)
            {
                return BadRequest();
            }

            // var list = await _productServices.GetAll();
            var list = _myShopUnitOfWork._productGenericRepository.GetAll();

            _myShopUnitOfWork.SaveDataToDB();
            return Ok(list);
        }



        [HttpPost("Login")]

        public async Task<ActionResult> Login(UserLoginRequestData userLogin)
        {
            var user_database = _myShopUnitOfWork._accountRepository.UserLogin(userLogin);
            if (user_database == null || user_database.Id <= 0)
            {
                return BadRequest();
            }


            var authClaims = new List<Claim>
            {new Claim(ClaimTypes.NameIdentifier, user_database.Id.ToString()),
                        new Claim(ClaimTypes.Name, user_database.FullName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()), };

            var JwtToken = CreateToken(authClaims);
            var token = new JwtSecurityTokenHandler().WriteToken(JwtToken);

            return Ok(token);
        }


        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    Id = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                    FullName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                };
            }
            return null;
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
