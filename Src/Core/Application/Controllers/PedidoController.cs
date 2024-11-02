using FIAP.Pos.Tech.Challenge.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Domain;
using FIAP.Pos.Tech.Challenge.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Domain.Models;
using FIAP.Pos.Tech.Challenge.Domain.Models.MercadoPago;
using FIAP.Pos.Tech.Challenge.Domain.Models.Pedido;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace FIAP.Pos.Tech.Challenge.Application.Controllers
{
    /// <summary>
    /// Regras da aplicação referente ao pedido
    /// </summary>
    public class PedidoController : IPedidoController
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IValidator<Domain.Entities.Pedido> _validator;
        private readonly IValidator<WebhookPagamento> _validatorWebhookPagamento;

        public PedidoController(IConfiguration configuration, IMediator mediator, 
            IValidator<Domain.Entities.Pedido> validator, 
            IValidator<WebhookPagamento> validatorWebhookPagamento)
        {
            _configuration = configuration;
            _mediator = mediator;
            _validator = validator;
            _validatorWebhookPagamento = validatorWebhookPagamento;
        }

        /// <summary>
        /// Valida a entidade
        /// </summary>
        /// <param name="entity">Entidade</param>
        public async Task<ModelResult> ValidateAsync(Domain.Entities.Pedido entity)
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
        public virtual async Task<ModelResult> PostAsync(Domain.Entities.Pedido entity)
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
        public virtual async Task<ModelResult> PutAsync(Guid id, Domain.Entities.Pedido entity)
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
        public virtual async ValueTask<PagingQueryResult<Domain.Entities.Pedido>> GetItemsAsync(IPagingQueryParam filter, Expression<Func<Domain.Entities.Pedido, object>> sortProp)
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
        public virtual async ValueTask<PagingQueryResult<Domain.Entities.Pedido>> ConsultItemsAsync(IPagingQueryParam filter, Expression<Func<Domain.Entities.Pedido, bool>> expression, Expression<Func<Domain.Entities.Pedido, object>> sortProp)
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
        ///  Webhook para notificação de pagamento.
        /// </summary>
        public async Task<ModelResult> WebhookPagamento(WebhookPagamento notificacao, IHeaderDictionary headers)
        {
            if (notificacao == null) throw new InvalidOperationException($"Necessário informar a notificacao");
           
            ModelResult ValidatorResult = new ModelResult(notificacao);

            FluentValidation.Results.ValidationResult validations = _validatorWebhookPagamento.Validate(notificacao);
            if (!validations.IsValid)
            {
                ValidatorResult.AddValidations(validations);
                return ValidatorResult;
            }

            if (ValidatorResult.IsValid)
            {
                var warnings = new List<string>();

                if (!headers.ContainsKey("client_id"))
                    warnings.Add("Consumidor não autorizado e/ou inválido!");
                else if (!headers["client_id"].Equals(_configuration["WebhookClientAutorized"]))
                    warnings.Add("Consumidor não autorizado e/ou inválido!");

                PedidoWebhookPagamentoCommand command = new(notificacao, warnings.ToArray());
                return await _mediator.Send(command);
            }

            return ValidatorResult;
        }

        /// <summary>
        ///  Mercado pago recebimento de notificação webhook.
        ///  https://www.mercadopago.com.br/developers/pt/docs/your-integrations/notifications/webhooks#editor_13
        /// </summary>
        public async Task<ModelResult> MercadoPagoWebhoock(MercadoPagoWebhoock notificacao)
        {
            throw new NotImplementedException("Será implementado se der tempo. se estiver vendo isso não deu :( !");
        }
    }
}
