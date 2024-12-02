using System.Diagnostics.CodeAnalysis;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models
{
    [ExcludeFromCodeCoverage(Justification = "Arquivo de configuração")]
    public class MongoDbSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }

}
