using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers
{
    internal class PedidoPutHandler : IRequestHandler<PedidoPutCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public PedidoPutHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(PedidoPutCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateAsync(command.Entity, command.BusinessRules);
        }
    }
}
