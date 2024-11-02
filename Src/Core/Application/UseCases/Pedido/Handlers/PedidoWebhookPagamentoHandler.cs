using FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Handlers
{
    internal class PedidoWebhookPagamentoHandler : IRequestHandler<PedidoWebhookPagamentoCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public PedidoWebhookPagamentoHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(PedidoWebhookPagamentoCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.WebhookPagamento(command.Entity, command.BusinessRules);
        }
    }
}
