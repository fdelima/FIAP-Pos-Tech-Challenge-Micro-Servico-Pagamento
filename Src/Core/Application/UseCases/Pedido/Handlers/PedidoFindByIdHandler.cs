using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers
{
    internal class PedidoFindByIdHandler : IRequestHandler<PedidoFindByIdCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public PedidoFindByIdHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(PedidoFindByIdCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.FindByIdAsync(command.Id);
        }
    }
}
