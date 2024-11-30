using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands
{
    internal class MercadoPagoWebhoockCommand : IRequest<ModelResult>
    {
        public MercadoPagoWebhoockCommand(MercadoPagoWebhoock entity,
            Guid idPedido,
            string[]? businessRules = null)
        {
            Entity = entity;
            IdPedido = idPedido;
            BusinessRules = businessRules;
        }

        public MercadoPagoWebhoock Entity { get; private set; }
        public Guid IdPedido { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}