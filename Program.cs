using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_DangXuanDuc_21103101079.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookContext") ?? throw new InvalidOperationException("Connection string 'BookContext' not found.")));

// Add services to the container.
builder.Services.AddHttpClient("API",client =>
{
    client.BaseAddress = new Uri("http://localhost:5260");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
