using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Commands
{
    public class MercadoPagoWebhoockCommand : IRequest<ModelResult>
    {
        public MercadoPagoWebhoockCommand(MercadoPagoWebhoock entity,
            Guid idPedido,
            string microServicoPedidoBaseAdress,
            string[]? businessRules = null)
        {
            Entity = entity;
            IdPedido = idPedido;
            MicroServicoPedidoBaseAdress = microServicoPedidoBaseAdress;
            BusinessRules = businessRules;
        }

        public MercadoPagoWebhoock Entity { get; private set; }
        public Guid IdPedido { get; private set; }
        public string MicroServicoPedidoBaseAdress { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}