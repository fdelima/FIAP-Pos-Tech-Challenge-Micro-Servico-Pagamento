using Microsoft.EntityFrameworkCore;
using System.Net;

namespace TestProject.Infra
{
    public class MongoTestFixture : IDisposable
    {
        //mongo
        const string network = "network-pagamento-test";
        private const string ImageName = "mongo:latest";
        private const string DataBaseName = "tech-challenge-micro-servico-pagamento-grupo-71";

        string _port; string _databaseContainerName;

        public MongoTestFixture(string databaseContainerName, string port)
        {
            if (DockerManager.UseDocker())
            {               
                if (!DockerManager.ContainerIsRunning(databaseContainerName))
                {
                    _port = port;
                    _databaseContainerName = databaseContainerName;
                    DockerManager.PullImageIfDoesNotExists(ImageName);
                    DockerManager.KillContainer(databaseContainerName);
                    DockerManager.KillVolume(databaseContainerName);

                    DockerManager.CreateNetWork(network);

                    DockerManager.RunContainerIfIsNotRunning(databaseContainerName,
                        $"run --name {databaseContainerName} " +
                        $"-p {port}:27017 " +
                        $"--network {network} " + 
                        $"-d {ImageName}");

                    Thread.Sleep(3000);
                }
            }
        }

        public FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Infra.Context GetDbContext()
        {
            string connectionString = $"mongodb://localhost:{_port}";

            var options = new DbContextOptionsBuilder<FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Infra.Context>()
                                .UseMongoDB(connectionString, DataBaseName).Options;

            return new FIAP.Pos.Tech.Challenge.Micro.Servico.Pagamento.Infra.Context(options);
        }

        public void Dispose()
        {
            if (DockerManager.UseDocker())
            {
                DockerManager.KillContainer(_databaseContainerName);
                DockerManager.KillVolume(_databaseContainerName);
            }
            GC.SuppressFinalize(this);
        }
    }
}
