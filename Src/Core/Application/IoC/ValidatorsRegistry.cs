using FIAP.Pos.Tech.Challenge.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Domain.Models.Pedido;
using FIAP.Pos.Tech.Challenge.Domain.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Pos.Tech.Challenge.Application.IoC
{
    internal static class ValidatorsRegistry
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            //TODO: Validators :: 3 - Adicione sua configuração aqui

            //Validators
            services.AddScoped(typeof(IValidator<Notificacao>), typeof(NotificacaoValidator));
            services.AddScoped(typeof(IValidator<Pedido>), typeof(PedidoValidator));
            services.AddScoped(typeof(IValidator<WebhookPagamento>), typeof(PedidoWebhookPagamentoValidator));
        }
    }
}
