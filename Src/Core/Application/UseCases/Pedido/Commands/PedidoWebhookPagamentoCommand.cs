using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models.Pedido;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands
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