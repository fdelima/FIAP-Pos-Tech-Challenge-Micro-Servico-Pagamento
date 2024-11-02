using FIAP.Pos.Tech.Challenge.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Commands
{
    internal class PedidoPostCommand : IRequest<ModelResult>
    {
        public PedidoPostCommand(Domain.Entities.Pedido entity,
            string[]? businessRules = null)
        {
            Entity = entity;
            BusinessRules = businessRules;
        }

        public Domain.Entities.Pedido Entity { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}