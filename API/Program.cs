using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//Create a web application instance

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);//Lifetime => Scoped

var app = builder.Build();// services container

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
