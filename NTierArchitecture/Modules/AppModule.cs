using NTierArchitecture.Modules.Email.Config;
using NTierArchitecture.Modules.TodoItem.Services;
using NTierArchitecture.Modules.TodoItem.Services.Impl;
using NTierArchitecture.Modules.TodoList.Services;
using NTierArchitecture.Modules.TodoList.Services.Impl;
using NTierArchitecture.Modules.User.Services;
using NTierArchitecture.Modules.User.Services.Impl;

namespace NTierArchitecture.Modules;

public static class AppModule
{
    public static IServiceCollection AddAppDependency(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddAuthServices(env);

        services.AddSampleServices(env);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddAuthServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IUserService, UserService>();
    }

    private static void AddSampleServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<ITodoListService, TodoListService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IModuleMarker));
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}
