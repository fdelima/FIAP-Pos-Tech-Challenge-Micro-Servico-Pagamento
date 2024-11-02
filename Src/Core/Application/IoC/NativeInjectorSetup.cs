using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Pos.Tech.Challenge.Application.IoC
{
    /// <summary>
    /// Configura a injeção de dependência
    /// </summary>
    public static class NativeInjectorSetup
    {
        /// <summary>
        /// Registra as dependências aos serviços da aplicação
        /// </summary>
        public static void RegisterAppDependencies(this IServiceCollection services)
        {
            services.RegisterDomainServices();
            services.RegisterValidators();
            services.RegisterAppControllers();
            services.RegisterCommands();
        }
    }
}
