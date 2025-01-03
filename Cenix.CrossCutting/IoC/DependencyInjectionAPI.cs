using Cenix.Domain.ConstantsVariables;
using Cenix.Infrastructure.Context;
using Cenix.Infrastructure.TablesDefinition;
using CenixPackage.CrossCutting.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CenixPackage.Application.DTO.CenixSettings;

namespace Cenix.CrossCutting.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection ServiceInjection(this IServiceCollection services)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseNpgsql(@$"Host={ConstantsVariables.DB_HOST};
                                    Port={ConstantsVariables.DB_PORT};
                                    Username={ConstantsVariables.DB_USER};
                                    Password={ConstantsVariables.DB_PASSWORD};
                                    Database={ConstantsVariables.DB_DATABASE}",
                                    npgsqlOptions =>
                                    {
                                        npgsqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                                        npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", Tables.DefaultSchema);
                                        npgsqlOptions.EnableRetryOnFailure(
                                                        maxRetryCount: 3,
                                                        maxRetryDelay: TimeSpan.FromSeconds(30),
                                                        errorCodesToAdd: null
                                                );
                                        options.EnableSensitiveDataLogging(true);
                                    });
                });



        // Cenix Package
        services.CenixServiceInjection(options =>
        {
            options.Jwt = new CenixJwtSettignsDTO
            {
                Key = ConstantsVariables.JWT_KEY,
                Issuer = ConstantsVariables.JWT_ISSUER,
                Audience = ConstantsVariables.JWT_AUDIENCE
            };

            options.Urls = new CenixUrlSettingsDTO
            {
                AiacosApi = ConstantsVariables.AIACOS_API,
                ZeusApi = ConstantsVariables.ZEUS_API
            };

            options.Redis = new CenixRedisSetiingsDTO
            {
                StringConnection = ConstantsVariables.REDIS_STRING_CONNECTION
            };
        });

        return services;
    }
}
