using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Handlers
{
    public class MercadoPagoWebhoockHandler : IRequestHandler<MercadoPagoWebhoockCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public MercadoPagoWebhoockHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(MercadoPagoWebhoockCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.MercadoPagoWebhoock(command.Entity, command.IdPedido, command.BusinessRules);
        }
    }
}
