using Microsoft.EntityFrameworkCore;
using WebCoreAPI;
using WebCoreAPI.EntitiesFrameWork.Dbcontext;
using WebCoreAPI.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<MyShopUnitOfWorkDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IClassB, ClassBimpl>();
builder.Services.AddTransient<IProductServices, ProductServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("x-my-custom-header", "middleware QUANNT");
//    await next();
//});
//app.UseMiddleware<CustomeMiddleWare>();
app.Run();
