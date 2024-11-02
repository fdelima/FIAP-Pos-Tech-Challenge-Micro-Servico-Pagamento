using FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Handlers
{
    internal class PedidoConsultarPagamentoHandler : IRequestHandler<PedidoConsultarPagamentoCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public PedidoConsultarPagamentoHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(PedidoConsultarPagamentoCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.ConsultarPagamentoAsync(command.Id);
        }
    }
}
