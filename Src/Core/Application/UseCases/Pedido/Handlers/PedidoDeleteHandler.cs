using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers
{
    internal class PedidoDeleteHandler : IRequestHandler<PedidoDeleteCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public PedidoDeleteHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(PedidoDeleteCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.DeleteAsync(command.Id, command.BusinessRules);
        }
    }
}
