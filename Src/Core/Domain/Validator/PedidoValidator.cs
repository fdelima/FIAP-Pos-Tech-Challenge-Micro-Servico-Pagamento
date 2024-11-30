using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Messages;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.ValuesObject;
using FluentValidation;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Validator
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
            RuleFor(c => c.IdPedido).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(c => c.IdDispositivo).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(c => c.IdCliente).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(c => c.Data).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(c => c.DataStatusPedido).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(c => c.Status)
                .Must(x => enmPedidoStatus.RECEBIDO.ToString().Equals(x))
                .WithMessage($"Status do pedido precisa ser: {enmPedidoStatus.RECEBIDO.ToString()}");
            RuleFor(c => c.StatusPagamento)
                .Must(x => enmPedidoStatusPagamento.PENDENTE.ToString().Equals(x))
                .WithMessage($"Status de pagamento precisa ser: {enmPedidoStatusPagamento.PENDENTE.ToString()}");

        }
    }
}
