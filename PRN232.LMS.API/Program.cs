using PRN232.LMS.API.Configurations;
using PRN232.LMS.API.Middlewares;
using PRN232.LMS.Models.Entities;
using PRN232.LMS.Repositories.Data;

var builder = WebApplication.CreateBuilder(args);

// Content Negotation
builder.Services.AddMvcConfiguration();
builder.Services.AddControllers();
// API versioning
builder.Services.AddApiVersion();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

// Database
builder.Services.AddDatabase(builder.Configuration);
// Service
builder.Services.AddDependencyInjection();
// Validator
builder.Services.AddFluentValidationConfig();
builder.Services.AddValidationConfiguration();
builder.Services.AddCustomJsonOptions();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LmsdbContext>();

    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            Role = "Admin",
            Student = new Student
            {
                Fullname = "Admin User",
                Email = "admin@gmail.com",
                Dateofbirth = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Studentcode = "STU001",
                Age = 25,
                Phonenumber = "0900000000"
            }
        });

        db.Users.Add(new User
        {
            Username = "user",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            Role = "User",
            Student = new Student
            {
                Fullname = "Normal User",
                Email = "user@gmail.com",
                Dateofbirth = new DateTime(2001, 5, 10, 0, 0, 0, DateTimeKind.Utc),
                Studentcode = "STU002",
                Age = 24,
                Phonenumber = "0911111111"
            }
        });

        db.SaveChanges();
    }

}

app.UseSwaggerConfiguration();
app.UseRequestLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalException();
app.MapControllers();
app.Run();