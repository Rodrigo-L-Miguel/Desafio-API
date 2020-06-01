using RestSharpNetCoreTemplate.Bases;
using NUnit.Framework;
using RestSharp;
using Requests.MantisBT.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issues
{
    [TestFixture,Order(2)]
    class FindIssueTest : TestBase
    {
         [Test]
        public void BuscaTarefaExistente()
        {
            string idTarefa = "24";
            string resultadoEsperado = "OK";

            FindIssueByIdRequest Solicitacao = new FindIssueByIdRequest(idTarefa);
            IRestResponse <dynamic> Resposta = Solicitacao.ExecuteRequest();
            
            string respondeCode = Resposta.StatusCode.ToString();
            Assert.IsTrue(respondeCode.Contains(resultadoEsperado));
        }
        
        [Test]
        public void BuscaTarefaInexistente()
        {
            #region Parameters
            string idTarefa = "200";
            string resultadoEsperado = "NotFound";
            #endregion

            FindIssueByIdRequest Solicitacao = new FindIssueByIdRequest(idTarefa);
            IRestResponse<dynamic> Resposta = Solicitacao.ExecuteRequest();
            
            string respondeCode = Resposta.StatusCode.ToString();

            Assert.IsTrue(respondeCode.Contains(resultadoEsperado));
        }
        [Test]
        public void BuscaTarefaParametroIncorreto()
        {
            string idTarefa = "@#%";
            string resultadoEsperado = "NotFound";

            FindIssueByIdRequest Solicitacao = new FindIssueByIdRequest(idTarefa);
            IRestResponse<dynamic> Resposta = Solicitacao.ExecuteRequest();

            Assert.AreEqual(resultadoEsperado,Resposta.StatusCode.ToString());
        }
        [Test]
        public void BuscaTarefaTokenIncorreto()
        {
            #region Parameters
            string idTarefa = "3";
            string token = "1234";
            string resultadoEsperado = "Forbidden";
            string descricaoErro = "API token not found";
            #endregion

            #region Actions
            FindIssueByIdRequest Adiciona = new FindIssueByIdRequest(idTarefa);
            Adiciona.UpdateToken(token);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), resultadoEsperado);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }

    }
}
