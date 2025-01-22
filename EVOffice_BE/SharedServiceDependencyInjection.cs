using EVOffice_BE.Infrastructures.Repositories;
using EVOffice_BE.Infrastructures.Repositories.Impl;
using EVOffice_BE.Shared.Claim;

namespace EVOffice_BE;

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
    }
}
