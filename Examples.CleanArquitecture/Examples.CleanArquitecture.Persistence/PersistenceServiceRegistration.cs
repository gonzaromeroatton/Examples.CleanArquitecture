using Examples.CleanArquitecture.Application.Contracts.Persistence;
using Examples.CleanArquitecture.Persistence.DatabaseContext;
using Examples.CleanArquitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.CleanArquitecture.Persistence;

/// <summary>
/// 
/// </summary>
public static class PersistenceServiceRegistration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PersonsDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PersonsConnectionString"));


            // No nos interesan problemas en las migraciones si utilizamos DateTime.Now o Guid.NewGuid()
            options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }
}
