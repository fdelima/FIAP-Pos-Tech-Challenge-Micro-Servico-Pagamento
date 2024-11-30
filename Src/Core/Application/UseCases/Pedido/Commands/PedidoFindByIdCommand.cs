using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands
{
    internal class PedidoFindByIdCommand : IRequest<ModelResult>
    {
        public PedidoFindByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}