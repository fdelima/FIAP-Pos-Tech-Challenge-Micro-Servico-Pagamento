using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands
{
    internal class PedidoDeleteCommand : IRequest<ModelResult>
    {
        public PedidoDeleteCommand(Guid id, string[]? businessRules = null)
        {
            Id = id;
            BusinessRules = businessRules;
        }

        public Guid Id { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}