using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests.MantisBT.Issues;
using System.Collections;

namespace RestSharpNetCoreTemplate.Tests.Issues
{
    [TestFixture, Order(3)]
    class DeleteIssueTest : TestBase
    {
        [Test]
        public void DeletarTarefa()
        {
            #region Parameters
            string idTarefa = "2";
            string resultadoEsperado = "NoContent";
            #endregion

            #region Actions
            DeleteIssueRequest Delete = new DeleteIssueRequest(idTarefa);
            IRestResponse<dynamic> Resposta = Delete.ExecuteRequest();
            #endregion

            Assert.AreEqual(resultadoEsperado,Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarTarefaInexistente()
        {
            #region Parameters
            string idTarefa = "30000";
            string resultadoEsperado = "NotFound";
            #endregion

            #region Actions
            DeleteIssueRequest Delete = new DeleteIssueRequest(idTarefa);

            IRestResponse<dynamic> Resposta = Delete.ExecuteRequest();
            #endregion

            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarTarefaTokenIncorreto()
        {
            #region Parameters
            string idTarefa = "3";
            string token = "1234";
            string resultadoEsperado = "Forbidden";
            string descricaoErro = "API token not found";
            #endregion

            #region Actions
            DeleteIssueRequest Adiciona = new DeleteIssueRequest(idTarefa);
            Adiciona.UpdateToken(token);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), resultadoEsperado);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }
        [Test]
        public void DeletarTarefaParametroInexistente()
        {
            string idTarefa = "@#%";
            string resultadoEsperado = "NotFound";

            DeleteIssueRequest Solicitacao = new DeleteIssueRequest(idTarefa);
            IRestResponse<dynamic> Resposta = Solicitacao.ExecuteRequest();

            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarTarefaTokenRelator()
        {
            #region Parameters
            string idTarefa = "1";
            string resultadoEsperado = "Forbidden";
            string token = JsonBuilder.ReturnParameterAppSettings("UPDATER_TOKEN");
            string descricaoErro = "Access denied to delete";
            #endregion

            #region Actions
            DeleteIssueRequest Delete = new DeleteIssueRequest(idTarefa);
            Delete.UpdateToken(token);
            IRestResponse<dynamic> Resposta = Delete.ExecuteRequest();
            #endregion

            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.StatusDescription.Contains(descricaoErro));
        }
        [Test]
        public void DeletarTarefaTokenVisualizador()
        {
            #region Parameters
            string idTarefa = "1";
            string resultadoEsperado = "Forbidden";
            string token = JsonBuilder.ReturnParameterAppSettings("VISUALIZER_TOKEN");
            string descricaoErro = "Access denied to delete";
            #endregion

            #region Actions
            DeleteIssueRequest Delete = new DeleteIssueRequest(idTarefa);
            Delete.UpdateToken(token);
            IRestResponse<dynamic> Resposta = Delete.ExecuteRequest();
            #endregion

            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.StatusDescription.Contains(descricaoErro));
        }

    }
}
