using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ReactTestApi.BusinessLogic.Interface;
using ReactTestApi.BusinessLogic.Manager;
using ReactTestApi.Context;
using ReactTestApi.Data.Interface;
using ReactTestApi.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Enable CORS
builder.Services.AddCors(c =>
{
	c.AddPolicy("Allow Origin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Configure DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("ReactTestApiCon"));
});

//Add Dependency
builder.Services.AddTransient<IDepartmentManager, DepartmentManager>();
builder.Services.AddTransient<IEmployeeManager, EmployeeManager>();

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//Enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

//Add Photofile directory
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
	RequestPath = "/Photos"
});