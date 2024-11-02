using FIAP.Pos.Tech.Challenge.Domain.ValuesObject;

namespace FIAP.Pos.Tech.Challenge.Domain.Models.Pedido
{
    public class WebhookPagamento
    {
        public Guid IdPedido { get; set; }
        public string StatusPagamento { get; set; }
    }
}
