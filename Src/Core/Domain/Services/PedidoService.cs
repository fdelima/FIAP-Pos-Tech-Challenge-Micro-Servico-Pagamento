using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models.Pedido;
using FluentValidation;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Services
{
    public class PedidoService : BaseService<Pedido>, IPedidoService
    {
        protected readonly IGateways<Notificacao> _notificacaoGateway;

        /// <summary>
        /// Lógica de negócio referentes ao pedido.
        /// </summary>
        /// <param name="gateway">Gateway de pedido a ser injetado durante a execução</param>
        /// <param name="validator">abstração do validador a ser injetado durante a execução</param>
        /// <param name="notificacaoGateway">Gateway de notificação a ser injetado durante a execução</param>
        /// <param name="dispositivoGateway">Gateway de dispositivo a ser injetado durante a execução</param>
        /// <param name="clienteGateway">Gateway de cliente a ser injetado durante a execução</param>
        /// <param name="produtoGateway">Gateway de produto a ser injetado durante a execução</param>
        public PedidoService(IGateways<Pedido> gateway,
            IValidator<Pedido> validator,
            IGateways<Notificacao> notificacaoGateway)
            : base(gateway, validator)
        {
            _notificacaoGateway = notificacaoGateway;
        }


        /// <summary>
        /// Regra para para consultar o pagamento de um pedido.
        /// </summary>
        public async Task<ModelResult> ConsultarPagamentoAsync(Guid id)
        {
            var result = await _gateway.FindByIdAsync(id);

            if (result == null)
                return ModelResultFactory.NotFoundResult<Pedido>();

            return ModelResultFactory.SucessResult(result.StatusPagamento);
        }

        /// <summary>
        ///  Regra de Webhook para notificação de pagamento.
        /// </summary>
        public async Task<ModelResult> WebhookPagamento(WebhookPagamento webhook, string[]? businessRules)
        {
            ModelResult ValidatorResult = new ModelResult();

            if (businessRules != null)
                ValidatorResult.AddError(businessRules);

            if (!ValidatorResult.IsValid)
                return ValidatorResult;

            var entity = await _gateway.FindByIdAsync(webhook.Pedido.IdPedido);

            if (entity == null)
            {
                entity = webhook.Pedido;
                await _gateway.InsertAsync(entity);
                await _gateway.CommitAsync();
                return ModelResultFactory.InsertSucessResult<Pedido>(entity);
            }
            else
            {
                entity.DataStatusPagamento = DateTime.Now;
                entity.StatusPagamento = webhook.StatusPagamento;
                await _gateway.UpdateAsync(entity);
                await _gateway.CommitAsync();
                return ModelResultFactory.UpdateSucessResult<Pedido>(entity);
            }
        }
    }
}
