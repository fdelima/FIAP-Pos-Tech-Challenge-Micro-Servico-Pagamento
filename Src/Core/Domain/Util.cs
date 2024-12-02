using System.Reflection;

namespace FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Domain
{
    public static class Util
    {
        public static Type[] GetTypesInNamespace(string nameSpace)
        {
            return Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                            .ToArray();
        }
    }
}
