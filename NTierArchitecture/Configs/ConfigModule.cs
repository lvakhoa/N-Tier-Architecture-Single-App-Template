using FluentValidation;
using FluentValidation.AspNetCore;

using NTierArchitecture.Modules;

namespace NTierArchitecture.Configs;

public static class ConfigModule
{
    public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        // Inject Jwt
        services.AddJwt(configuration);

        // Inject Swagger
        services.AddSwagger();

        // Inject Data Access
        services.AddDataAccess(configuration);

        // Inject Fluent Validation
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(IModuleMarker));
    }
}
