using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Handlers;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
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

            //Notificacao
            services.AddScoped<IRequestHandler<NotificacaoPostCommand, ModelResult>, NotificacaoPostHandler>();
            services.AddScoped<IRequestHandler<NotificacaoPutCommand, ModelResult>, NotificacaoPutHandler>();
            services.AddScoped<IRequestHandler<NotificacaoDeleteCommand, ModelResult>, NotificacaoDeleteHandler>();
            services.AddScoped<IRequestHandler<NotificacaoFindByIdCommand, ModelResult>, NotificacaoFindByIdHandler>();
            services.AddScoped<IRequestHandler<NotificacaoGetItemsCommand, PagingQueryResult<Notificacao>>, NotificacaoGetItemsHandler>();

            //Pedido
            services.AddScoped<IRequestHandler<PedidoPostCommand, ModelResult>, PedidoPostHandler>();
            services.AddScoped<IRequestHandler<PedidoPutCommand, ModelResult>, PedidoPutHandler>();
            services.AddScoped<IRequestHandler<PedidoDeleteCommand, ModelResult>, PedidoDeleteHandler>();
            services.AddScoped<IRequestHandler<PedidoFindByIdCommand, ModelResult>, PedidoFindByIdHandler>();
            services.AddScoped<IRequestHandler<PedidoGetItemsCommand, PagingQueryResult<Pedido>>, PedidoGetItemsHandler>();
            services.AddScoped<IRequestHandler<PedidoWebhookPagamentoCommand, ModelResult>, PedidoWebhookPagamentoHandler>();
            services.AddScoped<IRequestHandler<PedidoConsultarPagamentoCommand, ModelResult>, PedidoConsultarPagamentoHandler>();
        }
    }
}
