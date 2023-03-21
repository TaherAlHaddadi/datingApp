using API.Extensions;
var builder = WebApplication.CreateBuilder(args);//Create a web application instance

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors();

var app = builder.Build();// services container

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication(); // do you have a valid token?
app.UseAuthorization(); // OK! you have token what things are you allowed to do ?
app.MapControllers();

app.Run();