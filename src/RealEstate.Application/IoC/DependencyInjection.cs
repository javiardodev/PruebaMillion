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
            .AddMapping()
            .AddValidationsBehavior();

        return services;
    }

    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISecurityService, SecurityService>()
                .AddScoped<IOwnerService, OwnerService>()
                .AddScoped<IPropertyImageService, PropertyImageService>();

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