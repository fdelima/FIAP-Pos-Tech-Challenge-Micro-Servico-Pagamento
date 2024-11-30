using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Handlers
{
    internal class NotificacaoGetItemsHandler : IRequestHandler<NotificacaoGetItemsCommand, PagingQueryResult<Domain.Entities.Notificacao>>
    {
        private readonly IService<Domain.Entities.Notificacao> _service;

        public NotificacaoGetItemsHandler(IService<Domain.Entities.Notificacao> service)
        {
            _service = service;
        }

        public async Task<PagingQueryResult<Domain.Entities.Notificacao>> Handle(NotificacaoGetItemsCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Expression == null)
                return await _service.GetItemsAsync(command.Filter, command.SortProp);
            else
                return await _service.GetItemsAsync(command.Filter, command.Expression, command.SortProp);
        }
    }
}
