using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Infra.IoC;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.IoC;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.IoC
{
    /// <summary>
    /// Configura a injeção de dependência
    /// </summary>
    public static class NativeInjectorSetup
    {
        /// <summary>
        /// Registra as dependências aos serviços da aplicação
        /// </summary>
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfraDependencies(configuration);
            services.RegisterAppDependencies();
        }
    }
}
