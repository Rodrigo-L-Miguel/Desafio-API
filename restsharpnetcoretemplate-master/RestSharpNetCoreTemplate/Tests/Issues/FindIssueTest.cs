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
            FindIssueByIdRequest Solicitacao = new FindIssueByIdRequest(requestService,idTarefa);
            IRestResponse <dynamic> Resposta = Solicitacao.ExecuteRequest();
            string respondeCode = Resposta.StatusCode.ToString();
            Assert.IsTrue(respondeCode.Contains(resultadoEsperado));
        }
        
        [Test]
        public void TestaTarefaInexistente()
        {
            idTarefa = "200";
            string resultadoEsperado = "NotFound";
            FindIssueByIdRequest Solicitacao = new FindIssueByIdRequest(requestService, idTarefa);
            IRestResponse<dynamic> Resposta = Solicitacao.ExecuteRequest();
            string respondeCode = Resposta.StatusCode.ToString();
            Assert.IsTrue(respondeCode.Contains(resultadoEsperado));

        }
    }
}
