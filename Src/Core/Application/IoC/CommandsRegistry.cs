using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Handlers;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.IoC
{
    internal static class CommandsRegistry
    {
        public static void RegisterCommands(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //Pedido
            services.AddScoped<IRequestHandler<ReceberPedidoCommand, ModelResult>, ReceberPedidoHandler>();
            services.AddScoped<IRequestHandler<MercadoPagoWebhoockCommand, ModelResult>, MercadoPagoWebhoockHandler>();
            services.AddScoped<IRequestHandler<PedidoConsultarPagamentoCommand, ModelResult>, PedidoConsultarPagamentoHandler>();
        }
    }
}
