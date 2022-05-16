using EntityFrameworkTutorial.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlite().AddDbContext<SchoolContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var client = new SchoolContext())
{
    client.Database.EnsureCreated();

    client.Students.Add(new Student() { Id = 1, Name = "Daniel Mbaluka", Age = 30, Grade = null });
    // client.Students.Add(new Student() { Id = 2, Name = "Faith Mutunga", Age = 28, Grade = null });

    client.SaveChanges();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
