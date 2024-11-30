using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Interfaces;
using FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Models.MercadoPago;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain.Entities
{
    public class MercadoPagoWebhoock : IDomainEntity
    {
        public int Id { get; set; }

        public bool LiveMode { get; set; }

        public string Type { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserId { get; set; }

        public string ApiVersion { get; set; }

        public string Action { get; set; }

        public string Data { get; set; }

        public Expression<Func<IDomainEntity, bool>> AlterDuplicatedRule()
        {
            throw new NotImplementedException("Entidade externa não necessário implementação");
        }

        public Expression<Func<IDomainEntity, bool>> InsertDuplicatedRule()
        {
            throw new NotImplementedException("Entidade externa não necessário implementação");
        }

        public static explicit operator MercadoPagoWebhoock(MercadoPagoWebhoockModel model)
        {
            if (model == null)
                return null;

            return new MercadoPagoWebhoock
            {
                Id = model.Id,
                LiveMode = model.LiveMode,
                Type = model.Type,
                DateCreated = model.DateCreated,
                UserId = model.UserId,
                ApiVersion = model.ApiVersion,
                Action = model.Action,
                Data = JsonConvert.SerializeObject(model.Data)
            };
        }
    }
}
