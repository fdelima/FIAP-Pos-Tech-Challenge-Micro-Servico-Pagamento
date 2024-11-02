using FIAP.Pos.Tech.Challenge.Domain.Models;
using FIAP.Pos.Tech.Challenge.Domain.Models.Pedido;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Commands
{
    internal class PedidoWebhookPagamentoCommand : IRequest<ModelResult>
    {
        public PedidoWebhookPagamentoCommand(WebhookPagamento entity,
            string[]? businessRules = null)
        {
            Entity = entity;
            BusinessRules = businessRules;
        }

        public WebhookPagamento Entity { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}