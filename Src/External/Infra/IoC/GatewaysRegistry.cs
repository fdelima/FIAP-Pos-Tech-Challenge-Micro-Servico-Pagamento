using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Infra.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Infra.IoC
{
    internal static class GatewaysRegistry
    {
        public static void RegisterGateways(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IGateways<>), typeof(BaseGateway<>));
        }
    }
}