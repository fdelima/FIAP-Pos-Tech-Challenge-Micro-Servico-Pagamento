using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.ValuesObject;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models.Pedido
{
    public class WebhookPagamento
    {
        public Entities.Pedido Pedido { get; set; }
        public string StatusPagamento { get; set; }
    }
}
