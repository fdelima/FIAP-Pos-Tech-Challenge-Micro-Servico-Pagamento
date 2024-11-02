using FIAP.Pos.Tech.Challenge.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Notificacao.Commands
{
    internal class NotificacaoPostCommand : IRequest<ModelResult>
    {
        public NotificacaoPostCommand(Domain.Entities.Notificacao entity,
            string[]? businessRules = null)
        {
            Entity = entity;
            BusinessRules = businessRules;
        }

        public Domain.Entities.Notificacao Entity { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}