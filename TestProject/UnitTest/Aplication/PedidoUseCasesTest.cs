using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Extensions;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
using NSubstitute;
using System.Linq.Expressions;
using TestProject.MockData;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Commands;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Application.UseCases.Pedido.Handlers;

namespace TestProject.UnitTest.Aplication
{
    /// <summary>
    /// Classe de teste.
    /// </summary>
    public partial class PedidoUseCasesTest
    {
        private readonly IPedidoService _service;

        /// <summary>
        /// Construtor da classe de teste.
        /// </summary>
        public PedidoUseCasesTest()
        {
            _service = Substitute.For<IPedidoService>();
        }

        /// <summary>
        /// Testa a inserção com dados válidos
        /// </summary>
        [Theory]
        [MemberData(nameof(ObterDados), enmTipo.Inclusao, true, 3)]
        public async Task InserirComDadosValidos(Guid idDispositivo, Guid idCliente,
            DateTime data, string status, DateTime dataStatusPedido,
            string statusPagamento, DateTime dataStatusPagamento)
        {
            ///Arrange            
            var idPedido = Guid.NewGuid();
            var pedido = new Pedido
            {
                IdPedido = idPedido,
                IdDispositivo = idDispositivo,
                IdCliente = idCliente,
                Data = data,
                Status = status,
                DataStatusPedido = dataStatusPedido,
                StatusPagamento = statusPagamento,
                DataStatusPagamento = dataStatusPagamento

            };

            var command = new ReceberPedidoCommand(pedido);

            //Mockando retorno do serviço de domínio.
            _service.InsertAsync(pedido)
                .Returns(Task.FromResult(ModelResultFactory.SucessResult(pedido)));

            //Act
            var handler = new ReceberPedidoHandler(_service);
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
        }

        /// <summary>
        /// Testa a inserção com dados inválidos
        /// </summary>
        [Theory]
        [MemberData(nameof(ObterDados), enmTipo.Inclusao, false, 3)]
        public async Task InserirComDadosInvalidos(Guid idDispositivo, Guid idCliente,
            DateTime data, string status, DateTime dataStatusPedido,
            string statusPagamento, DateTime dataStatusPagamento)
        {
            ///Arrange    
            var idPedido = Guid.NewGuid();
            var pedido = new Pedido
            {
                IdPedido = idPedido,
                IdDispositivo = idDispositivo,
                IdCliente = idCliente,
                Data = data,
                Status = status,
                DataStatusPedido = dataStatusPedido,
                StatusPagamento = statusPagamento,
                DataStatusPagamento = dataStatusPagamento

            };

            var command = new ReceberPedidoCommand(pedido);

            //Mockando retorno do serviço de domínio.
            _service.InsertAsync(pedido)
                .Returns(Task.FromResult(ModelResultFactory.SucessResult(pedido)));

            //Act
            var handler = new ReceberPedidoHandler(_service);
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }

        /// <summary>
        /// Testa a consulta por id
        /// </summary>
        [Theory]
        [MemberData(nameof(ObterDados), enmTipo.Alteracao, true, 3)]
        public async Task ConsultarPedidoPorId(Guid idPedido, Guid idDispositivo, Guid idCliente,
            DateTime data, string status, DateTime dataStatusPedido,
            string statusPagamento, DateTime dataStatusPagamento)
        {
            ///Arrange            
            var pedido = new Pedido
            {
                IdPedido = idPedido,
                IdDispositivo = idDispositivo,
                IdCliente = idCliente,
                Data = data,
                Status = status,
                DataStatusPedido = dataStatusPedido,
                StatusPagamento = statusPagamento,
                DataStatusPagamento = dataStatusPagamento
            };

            var command = new PedidoConsultarPagamentoCommand(idPedido);

            //Mockando retorno do serviço de domínio.
            _service.FindByIdAsync(idPedido)
                .Returns(Task.FromResult(ModelResultFactory.SucessResult(pedido)));

            //Act
            var handler = new PedidoConsultarPagamentoHandler(_service);
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
        }


        #region [ Xunit MemberData ]

        /// <summary>
        /// Mock de dados
        /// </summary>
        public static IEnumerable<object[]> ObterDados(enmTipo tipo, bool dadosValidos, int quantidade)
        {
            switch (tipo)
            {
                case enmTipo.Inclusao:
                    if (dadosValidos)
                        return PedidoMock.ObterDadosValidos(quantidade);
                    else
                        return PedidoMock.ObterDadosInvalidos(quantidade);
                case enmTipo.Alteracao:
                    if (dadosValidos)
                        return PedidoMock.ObterDadosValidos(quantidade)
                            .Select(i => new object[] { Guid.NewGuid() }.Concat(i).ToArray());
                    else
                        return PedidoMock.ObterDadosInvalidos(quantidade)
                            .Select(i => new object[] { Guid.NewGuid() }.Concat(i).ToArray());
                case enmTipo.Consulta:
                    if (dadosValidos)
                        return PedidoMock.ObterDadosConsultaValidos(quantidade);
                    else
                        return PedidoMock.ObterDadosConsultaInValidos(quantidade);
                case enmTipo.ConsultaPorId:
                    if (dadosValidos)
                        return PedidoMock.ObterDadosConsultaPorIdValidos(quantidade);
                    else
                        return PedidoMock.ObterDadosConsultaPorIdInvalidos(quantidade);
                default:
                    return null;
            }
        }

        #endregion

    }
}
