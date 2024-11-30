using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models.Pedido;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces
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
