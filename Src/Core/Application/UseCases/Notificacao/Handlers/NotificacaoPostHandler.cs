using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Handlers
{
    internal class NotificacaoPostHandler : IRequestHandler<NotificacaoPostCommand, ModelResult>
    {
        private readonly IService<Domain.Entities.Notificacao> _service;

        public NotificacaoPostHandler(IService<Domain.Entities.Notificacao> service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(NotificacaoPostCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.InsertAsync(command.Entity, command.BusinessRules);
        }
    }
}
