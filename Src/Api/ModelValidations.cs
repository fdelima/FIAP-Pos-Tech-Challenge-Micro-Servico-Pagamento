using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Api
{
    [ExcludeFromCodeCoverage(Justification = "Arquivo de configuração")]
    public static class ModelValidations
    {
        internal static void ConfigureModelValidations(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
