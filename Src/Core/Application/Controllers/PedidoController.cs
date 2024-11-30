using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.Controllers
{
    /// <summary>
    /// Regras da aplicação referente ao pedido
    /// </summary>
    public class PedidoController : IPedidoController
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IValidator<Pedido> _validator;

        public PedidoController(IConfiguration configuration, IMediator mediator,
            IValidator<Pedido> validator)
        {
            _configuration = configuration;
            _mediator = mediator;
            _validator = validator;
        }

        /// <summary>
        /// Valida a entidade
        /// </summary>
        /// <param name="entity">Entidade</param>
        public async Task<ModelResult> ValidateAsync(Pedido entity)
        {
            ModelResult ValidatorResult = new ModelResult(entity);

            FluentValidation.Results.ValidationResult validations = _validator.Validate(entity);
            if (!validations.IsValid)
            {
                ValidatorResult.AddValidations(validations);
                return ValidatorResult;
            }

            return await Task.FromResult(ValidatorResult);
        }

        /// <summary>
        /// Envia a entidade para inserção ao domínio
        /// </summary>
        /// <param name="entity">Entidade</param>
        public virtual async Task<ModelResult> PostAsync(Pedido entity)
        {
            if (entity == null) throw new InvalidOperationException($"Necessário informar o Pedido");

            ModelResult ValidatorResult = await ValidateAsync(entity);

            if (ValidatorResult.IsValid)
            {
                PedidoPostCommand command = new(entity);
                return await _mediator.Send(command);
            }

            return ValidatorResult;
        }

        /// <summary>
        /// Envia a entidade para atualização ao domínio
        /// </summary>
        /// <param name="entity">Entidade</param>
        /// <param name="duplicatedExpression">Expressão para verificação de duplicidade.</param>
        public virtual async Task<ModelResult> PutAsync(Guid id, Pedido entity)
        {
            if (entity == null) throw new InvalidOperationException($"Necessário informar o Pedido");

            ModelResult ValidatorResult = await ValidateAsync(entity);

            if (ValidatorResult.IsValid)
            {
                PedidoPutCommand command = new(id, entity);
                return await _mediator.Send(command);
            }

            return ValidatorResult;
        }

        /// <summary>
        /// Envia a entidade para deleção ao domínio
        /// </summary>
        /// <param name="entity">Entidade</param>
        public virtual async Task<ModelResult> DeleteAsync(Guid id)
        {
            PedidoDeleteCommand command = new(id);
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Retorna a entidade
        /// </summary>
        /// <param name="entity">Entidade</param>
        public virtual async Task<ModelResult> FindByIdAsync(Guid id)
        {
            PedidoFindByIdCommand command = new(id);
            return await _mediator.Send(command);
        }


        /// <summary>
        /// Retorna as entidades
        /// </summary>
        /// <param name="filter">filtro a ser aplicado</param>
        public virtual async ValueTask<PagingQueryResult<Pedido>> GetItemsAsync(IPagingQueryParam filter, Expression<Func<Pedido, object>> sortProp)
        {
            if (filter == null) throw new InvalidOperationException("Necessário informar o filtro da consulta");

            PedidoGetItemsCommand command = new(filter, sortProp);
            return await _mediator.Send(command);
        }


        /// <summary>
        /// Retorna as entidades que atendem a expressão de filtro 
        /// </summary>
        /// <param name="expression">Condição que filtra os itens a serem retornados</param>
        /// <param name="filter">filtro a ser aplicado</param>
        public virtual async ValueTask<PagingQueryResult<Pedido>> ConsultItemsAsync(IPagingQueryParam filter, Expression<Func<Pedido, bool>> expression, Expression<Func<Pedido, object>> sortProp)
        {
            if (filter == null) throw new InvalidOperationException("Necessário informar o filtro da consulta");

            PedidoGetItemsCommand command = new(filter, expression, sortProp);
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Consulta o pagamento de um pedido.
        /// </summary> 
        public async Task<ModelResult> ConsultarPagamentoAsync(Guid id)
        {
            PedidoConsultarPagamentoCommand command = new(id);
            return await _mediator.Send(command);
        }


        /// <summary>
        ///  Notificação de pedido aguardando pagamento.
        /// </summary>
        public async Task<ModelResult> ReceberPedido(Pedido notificacao)
        {
            if (notificacao == null) throw new InvalidOperationException($"Necessário informar o pedido");

            ModelResult ValidatorResult = new ModelResult(notificacao);

            FluentValidation.Results.ValidationResult validations = _validator.Validate(notificacao);
            if (!validations.IsValid)
            {
                ValidatorResult.AddValidations(validations);
                return ValidatorResult;
            }

            if (ValidatorResult.IsValid)
            {
                PedidoPostCommand command = new(notificacao);
                return await _mediator.Send(command);
            }

            return ValidatorResult;
        }

        /// <summary>
        ///  Mercado pago recebimento de notificação webhook.
        ///  https://www.mercadopago.com.br/developers/pt/docs/your-integrations/notifications/webhooks#editor_13
        /// </summary>
        public async Task<ModelResult> MercadoPagoWebhoock(MercadoPagoWebhoock notificacao, Guid idPedido, IHeaderDictionary headers)
        {
            if (notificacao == null) throw new InvalidOperationException($"Necessário informar a notificacao");

            var warnings = new List<string>();
            if (!headers.ContainsKey("client_id"))
                warnings.Add("Consumidor não autorizado e/ou inválido!");
            else if (!headers["client_id"].Equals(_configuration["WebhookClientAutorized"]))
                warnings.Add("Consumidor não autorizado e/ou inválido!");

            MercadoPagoWebhoockCommand command = new(notificacao, idPedido, warnings.ToArray());
            return await _mediator.Send(command);
        }
    }
}
