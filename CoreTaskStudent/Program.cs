using CoreTaskStudent.Models;
using CoreTaskStudent.Repository;
using StudentDB = CoreTaskStudent.Repository.StudentDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");

//builder.Services.AddScoped<StudentDB>(provider => new StudentDB(connectionString));
// Register services
builder.Services.AddTransient<IStudentDB>(provider => new StudentDB(connectionString));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
