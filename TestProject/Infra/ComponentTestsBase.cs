//namespace TestProject.Infra
//{
//    public class ComponentTestsBase : IDisposable
//    {
//        private readonly SqlServerTestFixture _sqlserverTest;
//        internal readonly ApiTestFixture _apiTest;
//        private static int _tests = 0;

//        public ComponentTestsBase()
//        {
//            _tests += 1;
//            _sqlserverTest = new SqlServerTestFixture(
//                imageNameMssqlTools: "fdelima/fiap-pos-techchallenge-micro-servico-producao-gurpo-71-scripts-database:fase4-component-test",
//                containerNameMssqlTools: "mssql-tools-producao-component-test",
//                databaseContainerName: "sqlserver-db-producao-component-test", port: "1428");
//            _apiTest = new ApiTestFixture();
//            Thread.Sleep(10000);
//        }

//        public void Dispose()
//        {
//            _tests -= 1;
//            if (_tests == 0)
//            {
//                _sqlserverTest.Dispose();
//                _apiTest.Dispose();
//            }
//        }
//    }
//}
