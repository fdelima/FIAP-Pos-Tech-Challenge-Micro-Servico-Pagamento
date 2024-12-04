using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers
{
    public class PedidoConsultarPagamentoHandler : IRequestHandler<PedidoConsultarPagamentoCommand, ModelResult>
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
