//using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain;
//using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities;
//using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models;
//using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.ValuesObject;
//using Newtonsoft.Json;
//using System.Net.Http.Json;
//using TestProject.Infra;
//using Xunit.Gherkin.Quick;

//namespace TestProject.ComponenteTest
//{
//    /// <summary>
//    /// Classe de teste.
//    /// </summary>
//    [FeatureFile("./BDD/Features/ControlarPedidos.feature")]
//    public class PedidoControllerTest : Feature, IClassFixture<ComponentTestsBase>
//    {
//        private readonly ApiTestFixture _apiTest;
//        private ModelResult expectedResult;
//        Pedido _pedido;

//        /// <summary>
//        /// Construtor da classe de teste.
//        /// </summary>
//        public PedidoControllerTest(ComponentTestsBase data)
//        {
//            _apiTest = data._apiTest;
//        }
//        private class ActionResult
//        {
//            public List<string> Messages { get; set; }
//            public List<string> Errors { get; set; }
//            public Pedido Model { get; set; }
//            public bool IsValid { get; set; }
//        }

//        [Given(@"Recebendo um pedido na lanchonete vamos preparar o pedido")]
//        public void PrepararPedido()
//        {
//            var idPedido = Guid.NewGuid();
//            _pedido = new Pedido
//            {
//                IdPedido = idPedido,
//                IdCliente = Guid.NewGuid(),
//                IdDispositivo = Guid.NewGuid(),
//                Data = DateTime.Now,
//                DataStatusPagamento = DateTime.Now,
//                DataStatusPedido = DateTime.Now,
//                Status = enmPedidoStatus.RECEBIDO.ToString(),
//                StatusPagamento = enmPedidoStatusPagamento.APROVADO.ToString()
//            };
//        }

//        [And(@"Adicionar o pedido")]
//        public async Task AdicionarPedido()
//        {
//            expectedResult = ModelResultFactory.InsertSucessResult<Pedido>(_pedido);

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.PostAsJsonAsync(
//                "api/producao/pedido/InserirRecebido", _pedido);

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);

//            _pedido = actualResult.Model;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);

//            Assert.True(true);
//        }

//        [And(@"Encontrar o pedido")]
//        public async Task EncontrarPedido()
//        {
//            expectedResult = ModelResultFactory.SucessResult(_pedido);

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.GetAsync(
//                $"api/producao/pedido/{_pedido.IdPedido}");

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);
//            _pedido = actualResult.Model;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);
//        }

//        [And(@"Alterar o pedido")]
//        public async Task AlterarPedido()
//        {
//            expectedResult = ModelResultFactory.UpdateSucessResult<Pedido>(_pedido);

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.PutAsJsonAsync(
//                $"api/producao/pedido/{_pedido.IdPedido}", _pedido);

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);
//            _pedido = actualResult.Model;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);
//        }

//        [And(@"Consultar o pedido")]
//        public async Task ConsultarPedido()
//        {
//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.PostAsJsonAsync(
//                $"api/producao/pedido/consult", new PagingQueryParam<Pedido> { ObjFilter = _pedido });

//            var responseContent = await response.Content.ReadAsStringAsync();
//            dynamic actualResult = JsonConvert.DeserializeObject(responseContent);

//            Assert.True(actualResult.content != null);
//        }

//        [And(@"Listar o pedido")]
//        public async Task ListarPardido()
//        {
//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.GetAsync(
//                $"api/producao/pedido/Lista");

//            var responseContent = await response.Content.ReadAsStringAsync();
//            dynamic actualResult = JsonConvert.DeserializeObject(responseContent);

//            Assert.True(actualResult.content != null);
//        }

//        [And(@"Iniciar preparação do pedido")]
//        public async Task IniciarPreparacaoPedido()
//        {
//            expectedResult = ModelResultFactory.UpdateSucessResult<Pedido>(_pedido);

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.PatchAsJsonAsync(
//                $"api/producao/pedido/{_pedido.IdPedido}/IniciarPreparacao", _pedido.IdPedido);

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);
//            _pedido = actualResult.Model;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);
//        }

//        [And(@"Finalizar preparação do pedido")]
//        public async Task FinalizarPreparacaoPedido()
//        {
//            expectedResult = ModelResultFactory.UpdateSucessResult<Pedido>(_pedido);

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.PatchAsJsonAsync(
//                $"api/producao/pedido/{_pedido.IdPedido}/FinalizarPreparacao", _pedido.IdPedido);

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);
//            _pedido = actualResult.Model;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);
//        }

//        [When(@"Finalizar o pedido")]
//        public async Task FinalizarPedido()
//        {
//            expectedResult = ModelResultFactory.UpdateSucessResult<Pedido>(_pedido);

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.PatchAsJsonAsync(
//                $"api/producao/pedido/{_pedido.IdPedido}/Finalizar", _pedido.IdPedido);

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);
//            _pedido = actualResult.Model;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);
//        }

//        [Then(@"posso deletar o pedido")]
//        public async Task DeletarPedido()
//        {
//            expectedResult = ModelResultFactory.DeleteSucessResult<Pedido>();

//            var client = _apiTest.GetClient();
//            HttpResponseMessage response = await client.DeleteAsync(
//                $"api/producao/pedido/{_pedido.IdPedido}");

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<ActionResult>(responseContent);
//            _pedido = null;

//            Assert.Equal(expectedResult.IsValid, actualResult.IsValid);
//            Assert.Equal(expectedResult.Messages, actualResult.Messages);
//            Assert.Equal(expectedResult.Errors, actualResult.Errors);
//        }
//    }
//}
