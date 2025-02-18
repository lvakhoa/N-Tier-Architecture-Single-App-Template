using FluentValidation;
using FluentValidation.AspNetCore;

using NTierArchitecture;
using NTierArchitecture.Configs;
using NTierArchitecture.Database;
using NTierArchitecture.Exceptions;
using NTierArchitecture.Filters;
using NTierArchitecture.Middleware;
using NTierArchitecture.Modules;
using NTierArchitecture.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

builder.Services.AddConfig(builder.Configuration);

builder.Services.AddSharedService(builder.Environment);

builder.Services.AddAppDependency(builder.Environment);

builder.Services.AddEmailConfiguration(builder.Configuration);

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddProblemDetails();

var app = builder.Build();

using var scope = app.Services.CreateScope();

await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "NTierArchitecture V1"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.MapControllers();

app.UseExceptionHandler();

app.Run();

namespace NTierArchitecture
{
    public partial class Program { }
}
