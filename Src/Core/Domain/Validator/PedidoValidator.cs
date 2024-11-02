using FIAP.Pos.Tech.Challenge.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Domain.Messages;
using FIAP.Pos.Tech.Challenge.Domain.Models.Pedido;
using FIAP.Pos.Tech.Challenge.Domain.ValuesObject;
using FluentValidation;

namespace FIAP.Pos.Tech.Challenge.Domain.Validator
{
    /// <summary>
    /// Regras de validação da model
    /// </summary>
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        /// <summary>
        /// Contrutor das regras de validação da model
        /// </summary>
        public PedidoValidator()
        {
            RuleFor(c => c.IdDispositivo).NotEmpty().WithMessage(ValidationMessages.RequiredField);
        }
    }
    public class PedidoWebhookPagamentoValidator : AbstractValidator<WebhookPagamento>
    {
        public PedidoWebhookPagamentoValidator()
        {
            RuleFor(c => c.IdPedido).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(c => c.StatusPagamento)
                .Must(x => (new List<string>(Enum.GetNames(typeof(enmPedidoStatusPagamento)))).Count(e => e.Equals(x)) > 0)
                .WithMessage("Precisa ser algum desses status: " + string.Join(",", Enum.GetNames(typeof(enmPedidoStatusPagamento))));
        }
    }
}
