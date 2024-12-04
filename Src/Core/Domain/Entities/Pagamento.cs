using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using System.Linq.Expressions;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities
{
    public class Pagamento : IDomainEntity
    {
        public Guid Id { get; set; }
        public string Origem { get; set; }

        public Expression<Func<IDomainEntity, bool>> AlterDuplicatedRule()
        {
            throw new NotImplementedException("Entidade externa não necessário implementação");
        }

        public Expression<Func<IDomainEntity, bool>> InsertDuplicatedRule()
        {
            throw new NotImplementedException("Entidade externa não necessário implementação");
        }
    }
}
