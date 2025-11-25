using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Examples.CleanArquitecture.Application;

/// <summary>
/// Registra y configura los servicios pertenecientes a la capa Application.
/// </summary>
/// <remarks>
/// Esta clase expone métodos de extensión para centralizar la configuración
/// de librerías y componentes utilizados por la capa Application, por ejemplo
/// AutoMapper y MediatR.
/// </remarks>
public static class ApplicationServiceRegistration
{
    /// <summary>
    /// Registra los servicios y configuraciones necesarios para la capa Application.
    /// </summary>
    /// <param name="services">Colección de servicios donde se añadirán las dependencias.</param>
    /// <returns>La misma instancia de <see cref="IServiceCollection"/> para permitir encadenamiento.</returns>
    /// <remarks>
    /// - Configura AutoMapper registrando los perfiles encontrados en las asambleas cargadas del dominio de la aplicación.
    /// - Configura MediatR registrando los handlers presentes en la asamblea que contiene esta clase.
    /// </remarks>
    /// <example>
    /// services.AddApplicationServices();
    /// </example>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            // TODO: llevar la api key a un secrets manager o variable de entorno
            cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzk0MjY4ODAwIiwiaWF0IjoiMTc2Mjc4NDU1MyIsImFjY291bnRfaWQiOiIwMTlhNmUyNTRjZTk3MDI5OTgxMDk3YzM0OGMwMDViMyIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazlxMmJhMzUwMHpqenp3MnZrcms4aDFzIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.pv3R8tTjS8PTjlwU9euSYPWpCKhb-5VKRHpAYEsGnnPe8HzXqp98sPFOB_IT-ERUjyUKyZfY9GioFptnjsi-WIfNDSAANP_7wrQE_42GCdaKFiIS8ZIo4Ls-F-_oQqGWuCwcBcqklLQyZzjlglZIo0xBs4w2BeeacC6vOQM9Gl3J8tvk9nFYosiy7qUvRyItlXcXX8AtnGTobAfCC1njYWpNfbWVSlnPJEANjyrSR8C7U3S0c8iajg8kAqeiXRswEWU5RWd6J2msyXqelp490lQysqnFqaJKH01FhWwWR0hQUo8wEaWZkSZCn-uC4dfOxeKr2bM-YNhruponv5gQRw";
        }, AppDomain.CurrentDomain.GetAssemblies());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
