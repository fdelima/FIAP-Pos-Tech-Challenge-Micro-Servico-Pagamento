using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands
{
    internal class PedidoPutCommand : IRequest<ModelResult>
    {
        public PedidoPutCommand(Guid id, Domain.Entities.Pedido entity,
            string[]? businessRules = null)
        {
            Id = id;
            Entity = entity;
            BusinessRules = businessRules;
        }

        public Guid Id { get; private set; }
        public Domain.Entities.Pedido Entity { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}