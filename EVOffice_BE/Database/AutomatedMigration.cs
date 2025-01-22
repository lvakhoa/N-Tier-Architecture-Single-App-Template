using EVOffice_BE.Modules.User.Config;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EVOffice_BE.Database;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DatabaseContext>();

        if (context.Database.IsMySql()) await context.Database.MigrateAsync();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        await DatabaseContextSeed.SeedDatabaseAsync(context, userManager);
    }
}
