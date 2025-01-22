using EVOffice_BE.Modules;
using EVOffice_BE.Modules.Email.Config;
using EVOffice_BE.Modules.Email.Services;
using EVOffice_BE.Modules.Email.Services.DevImpl;
using EVOffice_BE.Modules.Email.Services.Impl;
using EVOffice_BE.Modules.Template.Services;
using EVOffice_BE.Modules.Template.Services.Impl;
using EVOffice_BE.Modules.TodoItem.Services;
using EVOffice_BE.Modules.TodoItem.Services.Impl;
using EVOffice_BE.Shared.Claim;

namespace EVOffice_BE;

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
