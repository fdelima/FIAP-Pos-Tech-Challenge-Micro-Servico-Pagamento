﻿using FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Domain;
using FIAP.Pos.Tech.Challenge.Domain.Interfaces;
using MediatR;

namespace FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Handlers
{
    internal class PedidoGetItemsHandler : IRequestHandler<PedidoGetItemsCommand, PagingQueryResult<Domain.Entities.Pedido>>
    {
        private readonly IPedidoService _service;

        public PedidoGetItemsHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<PagingQueryResult<Domain.Entities.Pedido>> Handle(PedidoGetItemsCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Expression == null)
                return await _service.GetItemsAsync(command.Filter, command.SortProp);
            else
                return await _service.GetItemsAsync(command.Filter, command.Expression, command.SortProp);
        }
    }
}
