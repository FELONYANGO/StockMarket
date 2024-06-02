using ApiBackend.Data;
using ApiBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();//adding controllers service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//wire the stock repo context
builder.Services.AddScoped<StockRepo>();
builder.Services.AddScoped<CommentRepo>();
//add newtonsoft json
builder.Services.AddControllers().AddNewtonsoftJson(Options =>
{
    Options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});


//connection to tjhe db
builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//map the controller
app.MapControllers();

app.Run();

