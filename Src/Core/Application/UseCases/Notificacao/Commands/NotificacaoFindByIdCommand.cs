using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands
{
    internal class NotificacaoFindByIdCommand : IRequest<ModelResult>
    {
        public NotificacaoFindByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}