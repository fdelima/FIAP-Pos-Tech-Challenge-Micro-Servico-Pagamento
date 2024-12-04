using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers
{
    public class ReceberPedidoHandler : IRequestHandler<ReceberPedidoCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public ReceberPedidoHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(ReceberPedidoCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.ReceberPedido(command.Entity, command.BusinessRules);
        }
    }
}
