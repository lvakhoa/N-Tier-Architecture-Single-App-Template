using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using NTierArchitecture.Modules.User.Config;

namespace NTierArchitecture.Database;

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
