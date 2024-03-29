using Microsoft.EntityFrameworkCore;
using RegistrosAplicada.Api.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(op => op.UseSqlite(ConStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//Cors
app.UseCors(options =>
{
	options.AllowAnyHeader();
	options.AllowAnyMethod();
	options.AllowAnyOrigin();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
