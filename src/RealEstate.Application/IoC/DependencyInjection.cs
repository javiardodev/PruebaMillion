using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
//using RealEstate.Application.Validators;
//using FluentValidation;

namespace RealEstate.Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddFluentValidationAutoValidation()
        //        .AddFluentValidationClientsideAdapters();
                //.AddValidatorsFromAssemblyContaining<UserInValidator>();

        return services;
    }
}