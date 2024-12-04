﻿using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces
{
    public interface IPedidoService : IService<Pedido>
    {
        /// <summary>
        /// Consulta o pagamento de um pedido.
        /// </summary> 
        Task<ModelResult> ConsultarPagamentoAsync(Guid id);

        /// <summary>
        ///  Notificação de pedido aguardando pagamento.
        /// </summary>
        Task<ModelResult> ReceberPedido(Pedido notificacao, string[]? businessRules = null);

        /// <summary>
        ///  Mercado pago recebimento de notificação webhook.
        ///  https://www.mercadopago.com.br/developers/pt/docs/your-integrations/notifications/webhooks#editor_13
        /// </summary>
        Task<ModelResult> MercadoPagoWebhoock(MercadoPagoWebhoock notificacao, Guid idPedido, string[]? businessRules = null);
    }
}
