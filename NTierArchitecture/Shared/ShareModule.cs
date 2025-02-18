using NTierArchitecture.Modules.Email.Services;
using NTierArchitecture.Modules.Email.Services.DevImpl;
using NTierArchitecture.Modules.Email.Services.Impl;
using NTierArchitecture.Modules.Template.Services;
using NTierArchitecture.Modules.Template.Services.Impl;
using NTierArchitecture.Shared.Claim;

namespace NTierArchitecture.Shared;

public static class SharedServiceDependencyInjection
{
    public static IServiceCollection AddSharedService(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IClaimService, ClaimService>();

        services.AddScoped<ITemplateService, TemplateService>();

        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
    }
}
