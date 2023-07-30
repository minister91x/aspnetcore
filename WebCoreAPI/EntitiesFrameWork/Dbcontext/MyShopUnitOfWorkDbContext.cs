using Microsoft.EntityFrameworkCore;
using WebCoreAPI.EntitiesFrameWork.Entities;

namespace WebCoreAPI.EntitiesFrameWork.Dbcontext
{
    public class MyShopUnitOfWorkDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyShopUnitOfWorkDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Product>? sanpham { get; set; }

        public DbSet<User> user { get; set; }

    }
}
