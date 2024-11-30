using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Handlers
{
    internal class NotificacaoPutHandler : IRequestHandler<NotificacaoPutCommand, ModelResult>
    {
        private readonly IService<Domain.Entities.Notificacao> _service;

        public NotificacaoPutHandler(IService<Domain.Entities.Notificacao> service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(NotificacaoPutCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateAsync(command.Entity, command.BusinessRules);
        }
    }
}
