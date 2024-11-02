using FIAP.Pos.Tech.Challenge.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Notificacao.Commands
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