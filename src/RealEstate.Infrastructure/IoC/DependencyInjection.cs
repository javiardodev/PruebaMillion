using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Common.Interfaces;
using RealEstate.CrossCutting.Configuration.Databases;
using RealEstate.CrossCutting.Configuration.Jwt;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Services.Security;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddJwtConfig()
                .AddDbConfig()
                .AddPersistence(config)
                .AddJwtAuthentication()
                .AddJwtAuthorization();

        return services;
    }

    private static IServiceCollection AddDbConfig(this IServiceCollection services)
    {
        services.AddOptions<DbCredentials>()
                .BindConfiguration(nameof(DbCredentials))
                .ValidateDataAnnotations()
                .ValidateOnStart();

        services.AddSingleton(sp => sp.GetRequiredService<IOptions<DbCredentials>>().Value);

        return services;
    }

    private static IServiceCollection AddJwtConfig(this IServiceCollection services)
    {
        services.AddOptions<JwtCredentials>()
                .BindConfiguration(nameof(JwtCredentials))
                .ValidateDataAnnotations()
                .ValidateOnStart();

        services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtCredentials>>().Value);

        return services;
    }

    private static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApiDbContext>((sp, db) =>
                    db.UseSqlServer(sp.GetRequiredService<IOptions<DbCredentials>>().Value.SqlServer))
                .AddScoped<ISecurityRepository, SecurityRepository>();
              //.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

        return services;
    }

    private static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization();

        return services;
    }
}