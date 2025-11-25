using Examples.CleanArquitecture.Application.Contracts.Email;
using Examples.CleanArquitecture.Application.Contracts.Logging;
using Examples.CleanArquitecture.Application.Models.Email;
using Examples.CleanArquitecture.Infraestructure.EmailService;
using Examples.CleanArquitecture.Infraestructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.CleanArquitecture.Infraestructure;

/// <summary>
/// 
/// </summary>
public static class InfraestructureServiceRegistration
{
    /// <summary>
    /// Registers infrastructure services and configurations into the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <remarks>This method configures email settings, registers an email sender implementation, and adds a
    /// generic application logger.</remarks>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
    /// <param name="configuration">The application configuration used to bind settings and configure services.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Corregido: Usar Bind para configurar EmailSettings
        services.Configure<EmailSettings>(options =>
            configuration.GetSection("EmailSettings").Bind(options));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
