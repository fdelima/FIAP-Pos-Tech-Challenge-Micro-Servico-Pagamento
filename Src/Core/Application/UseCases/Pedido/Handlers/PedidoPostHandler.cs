using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers
{
    internal class PedidoPostHandler : IRequestHandler<PedidoPostCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public PedidoPostHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(PedidoPostCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.InsertAsync(command.Entity, command.BusinessRules);
        }
    }
}
