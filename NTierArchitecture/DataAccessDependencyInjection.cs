using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using NTierArchitecture.Database;
using NTierArchitecture.Infrastructures.Repositories;
using NTierArchitecture.Infrastructures.Repositories.Impl;
using NTierArchitecture.Modules.User.Config;

namespace NTierArchitecture;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddIdentity();

        services.AddRepositories();

        services.AddUnitOfWorks();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        services.AddScoped<ITodoListRepository, TodoListRepository>();
    }

    private static void AddUnitOfWorks(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

        services.AddDbContext<DatabaseContext>(options =>
            options.UseMySql(databaseConfig?.ConnectionString,
                ServerVersion.AutoDetect(databaseConfig?.ConnectionString),
                opt =>
                    opt
                        .MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
                        .UseNewtonsoftJson()));
    }

    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }
}

// TODO move outside?
public class DatabaseConfiguration
{
    public string ConnectionString { get; set; }
}
