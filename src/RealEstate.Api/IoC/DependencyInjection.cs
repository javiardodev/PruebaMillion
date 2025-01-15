using RealEstate.CrossCutting.Configuration.Databases;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Threading.RateLimiting;
using Serilog;
using FluentValidation.AspNetCore;
using RealEstate.Api.Validations;
using FluentValidation;

namespace RealEstate.Api.IoC;

/// <summary>
/// 
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registry about Serilog tool
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static void UseSerilogLogging(this IHostBuilder builder)
    {
        builder.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer()
                .AddCorsCustom()
                .AddCustomValidations()
                .AddSwagger()
                .AddProblemDetails()
                .AddChecks();

        //Restrict request
        //services.AddRateLimiter(options =>
        //{
        //    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        //        RateLimitPartition.GetFixedWindowLimiter(
        //            httpContext.Connection.RemoteIpAddress.ToString(), partition =>
        //                new FixedWindowRateLimiterOptions
        //                {
        //                    AutoReplenishment = true,
        //                    PermitLimit = 10,
        //                    QueueLimit = 0,
        //                    Window = TimeSpan.FromSeconds(1)
        //                }));
        //});

        return services;
    }

    private static IServiceCollection AddCustomValidations(this IServiceCollection services)
    {
        return services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining<CredentialsRequestValidator>();
    }

    private static IServiceCollection AddCorsCustom(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowCors", policy =>
                policy.WithOrigins("*")
                      .AllowAnyMethod()
                      .AllowAnyHeader());
        });

        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "RealEstateAPI",
                Description = "Test Service - Web API for managing Users",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Martinez - Contact",
                    Url = new Uri("https://linkedin.com/in/javierski")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://example.com/license")
                }
            });

            options.IncludeXmlComments(Path.Combine(
                    AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}.",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                Array.Empty<string>()
                }
            });
        });

        return services;
    }

    private static IServiceCollection AddChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
                .AddSqlServer(sp =>
                    sp.GetRequiredService<IOptions<DbCredentials>>().Value.SqlServer,
                    name: "SQLServer",
                    tags: ["database", "critical"]
                );

        return services;
    }
}