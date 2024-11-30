using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.Controllers;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.IoC
{
    internal static class ControllersRegistry
    {
        public static void RegisterAppControllers(this IServiceCollection services)
        {
            //Controlles
            services.AddScoped(typeof(IPedidoController), typeof(PedidoController));
        }
    }
}