using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.ValuesObject;
using MediatR;
using System.Net.Http.Json;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.MercadoPago.Handlers
{
    public class MercadoPagoWebhoockHandler : IRequestHandler<MercadoPagoWebhoockCommand, ModelResult>
    {
        private readonly IPedidoService _service;

        public MercadoPagoWebhoockHandler(IPedidoService service)
        {
            _service = service;
        }

        public async Task<ModelResult> Handle(MercadoPagoWebhoockCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _service.MercadoPagoWebhoock(command.Entity, command.IdPedido, command.BusinessRules);

            if (result.IsValid)
            {
                try
                {
                    var producaoClient = Util.GetClient(command.MicroServicoPedidoBaseAdress);

                    HttpResponseMessage response =
                     await producaoClient.PutAsJsonAsync($"api/Pedido/ReceberStatusPagamento/{command.IdPedido}", enmPedidoStatusPagamento.APROVADO);

                    if (!response.IsSuccessStatusCode)
                        result.AddMessage("Não foi possível enviar status do pagamento do pedido.");
                }
                catch (Exception)
                {
                    result.AddMessage("Falha ao conectar ao pedido.");
                }
            }

            return result;
        }
    }
}
