using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Repositories.Data;

namespace PRN232.LMS.API.Middlewares
{
    public static class DatabaseInitializer
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LmsdbContext>();

                await db.Database.MigrateAsync();
                DbSeeder.Seed(db);
            }
        }
    }

}