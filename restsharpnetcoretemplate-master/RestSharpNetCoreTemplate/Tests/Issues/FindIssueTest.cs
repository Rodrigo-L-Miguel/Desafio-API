using RestSharpNetCoreTemplate.Bases;
using NUnit.Framework;
using RestSharp;
using Requests.MantisBT.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issues
{
    [TestFixture]
    class FindIssueTest : TestBase
    {
        #region Parameters
        private string idTarefa { get; set; }
        static string requestService = "/api/rest/issues/{issueid}";
        #endregion

        [Test]
        public void TestaTarefaExistente()
        {
            idTarefa = "1";
            string resultadoEsperado = "OK";
            FindIssueByIdRequest cliente = new FindIssueByIdRequest(requestService,idTarefa);
            IRestResponse <dynamic> request = cliente.ExecuteRequest();
            string respondeCode = request.StatusCode.ToString();
            Assert.IsTrue(respondeCode.Contains(resultadoEsperado));
        }
        
        [Test]
        public void TestaTarefaInexistente()
        {
            idTarefa = "200";
            string resultadoEsperado = "NotFound";
            FindIssueByIdRequest cliente = new FindIssueByIdRequest(requestService, idTarefa);
            IRestResponse<dynamic> request = cliente.ExecuteRequest();
            string respondeCode = request.StatusCode.ToString();
            Assert.IsTrue(respondeCode.Contains(resultadoEsperado));

        }
    }
}
