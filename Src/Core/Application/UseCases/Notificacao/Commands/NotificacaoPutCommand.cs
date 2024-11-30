using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands
{
    internal class NotificacaoPutCommand : IRequest<ModelResult>
    {
        public NotificacaoPutCommand(Guid id, Domain.Entities.Notificacao entity,
            string[]? businessRules = null)
        {
            Id = id;
            Entity = entity;
            BusinessRules = businessRules;
        }

        public Guid Id { get; private set; }
        public Domain.Entities.Notificacao Entity { get; private set; }
        public string[]? BusinessRules { get; private set; }
    }
}