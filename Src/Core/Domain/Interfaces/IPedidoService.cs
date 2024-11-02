using FIAP.Pos.Tech.Challenge.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Domain.Models;
using FIAP.Pos.Tech.Challenge.Domain.Models.Pedido;

namespace FIAP.Pos.Tech.Challenge.Domain.Interfaces
{
    public interface IPedidoService : IService<Pedido>
    {
        /// <summary>
        /// Consulta o pagamento de um pedido.
        /// </summary> 
        Task<ModelResult> ConsultarPagamentoAsync(Guid id);

        /// <summary>
        ///  Webhook para notificação de pagamento.
        /// </summary>
        Task<ModelResult> WebhookPagamento(WebhookPagamento entity, string[]? businessRules);
    }
}
