using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Handlers
{
    internal class NotificacaoDeleteHandler : IRequestHandler<NotificacaoDeleteCommand, ModelResult>
    {
        private readonly IService<Domain.Entities.Notificacao> _service;

        public NotificacaoDeleteHandler(IService<Domain.Entities.Notificacao> service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(NotificacaoDeleteCommand command, CancellationToken cancellationToken = default)
        {
            return await _service.DeleteAsync(command.Id, command.BusinessRules);
        }
    }
}
