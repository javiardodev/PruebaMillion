using Microsoft.Extensions.DependencyInjection;
//using FluentValidation.AspNetCore;
//using RealEstate.Application.Validators;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Services;

namespace RealEstate.Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices()
                .AddValidationsBehavior();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISecurityService, SecurityService>();
        //        .AddScoped<IAuthService, AuthService>()
        //        .AddScoped<ITokenService, TokenService>();

        return services;
    }

    private static IServiceCollection AddValidationsBehavior(this IServiceCollection services)
    {
        //services.AddFluentValidationAutoValidation()
        //        .AddFluentValidationClientsideAdapters();
                //.AddValidatorsFromAssemblyContaining<ClassValidatorApplication>();

        return services;
    }
}