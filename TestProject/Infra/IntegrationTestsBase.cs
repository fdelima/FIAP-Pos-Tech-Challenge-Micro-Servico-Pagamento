//namespace TestProject.Infra
//{
//    public class IntegrationTestsBase : IDisposable
//    {
//        internal readonly SqlServerTestFixture _sqlserverTest;
//        private static int _tests = 0;

//        public IntegrationTestsBase()
//        {
//            _tests += 1;
//            _sqlserverTest = new SqlServerTestFixture(
//                imageNameMssqlTools: "fdelima/fiap-pos-techchallenge-micro-servico-producao-gurpo-71-scripts-database:fase4-test",
//                containerNameMssqlTools: "mssql-tools-producao-test",
//                databaseContainerName: "sqlserver-db-producao-test", port: "1434");
//            Thread.Sleep(10000);
//        }

//        public void Dispose()
//        {
//            _tests -= 1;
//            if (_tests == 0)
//            {
//                _sqlserverTest.Dispose();
//            }
//        }
//    }
//}
