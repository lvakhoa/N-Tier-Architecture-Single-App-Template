using NTierArchitecture.Modules;
using NTierArchitecture.Modules.Email.Config;
using NTierArchitecture.Modules.Email.Services;
using NTierArchitecture.Modules.Email.Services.DevImpl;
using NTierArchitecture.Modules.Email.Services.Impl;
using NTierArchitecture.Modules.Template.Services;
using NTierArchitecture.Modules.Template.Services.Impl;
using NTierArchitecture.Modules.TodoItem.Services;
using NTierArchitecture.Modules.TodoItem.Services.Impl;

namespace NTierArchitecture;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<ITemplateService, TemplateService>();

        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
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
