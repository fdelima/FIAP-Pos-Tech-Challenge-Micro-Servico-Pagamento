using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Notificacao.Commands
{
    internal class NotificacaoGetItemsCommand : IRequest<PagingQueryResult<Domain.Entities.Notificacao>>
    {
        public NotificacaoGetItemsCommand(IPagingQueryParam filter, Expression<Func<Domain.Entities.Notificacao, object>> sortProp)
        {
            Filter = filter;
            SortProp = sortProp;
        }

        public NotificacaoGetItemsCommand(IPagingQueryParam filter,
            Expression<Func<Domain.Entities.Notificacao, bool>> expression, Expression<Func<Domain.Entities.Notificacao, object>> sortProp)
            : this(filter, sortProp)
        {
            Expression = expression;
        }

        public IPagingQueryParam Filter { get; }
        public Expression<Func<Domain.Entities.Notificacao, bool>> Expression { get; }

        public Expression<Func<Domain.Entities.Notificacao, object>> SortProp { get; }
    }
}