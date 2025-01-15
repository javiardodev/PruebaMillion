using Microsoft.Extensions.DependencyInjection;
using RealEstate.CrossCutting.Utils.SeriLog;

namespace RealEstate.CrossCutting.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddCrossCutting(this IServiceCollection services)
    {
        services.AddSerilogLogging();

        return services;
    }

    public static IServiceCollection AddSerilogLogging(this IServiceCollection services)
    {
        services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

        return services;
    }
}